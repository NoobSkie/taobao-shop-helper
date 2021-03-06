USE [SLS_ZJY]
GO
/****** Object:  StoredProcedure [dbo].[P_InitiateScheme]    Script Date: 05/30/2010 23:29:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_InitiateScheme]
(
	@UserID bigint,				-- 用户ID
	@IsuseID bigint,			-- 期号ID
	@PlayTypeID int,			-- 玩法ID
	@Title varchar(100),		-- 方案标题
	@Description varchar(max),			-- 方案描述
	@LotteryNumber varchar(max),		-- 彩票号码
	@UploadFileContent varchar(max),	-- 上传的原始文件内容(分析之前)
	@Multiple int,				-- 倍数
	@Money money,				-- 方案金额
	@AssureMoney money,			-- 保底金额
	@Share int,					-- 份数
	@BuyShare int,				-- 发起人认购份数
	@OpenUsers varchar(8000),	-- 招股对象列表
	@SecrecyLevel smallint,		-- 保密级别
	@SchemeBonusScale float,	--佣金比例

	@SchemeID bigint output,
	@ReturnDescription varchar(100) output
)

AS

BEGIN
	SET NOCOUNT ON;
	
	set @SchemeID = -1
	set @ReturnDescription = ''
	
	declare @Code varchar(20)
	declare @Isuse varchar(20)
	declare @SchemeNumber varchar(50)
	declare @StartTime datetime, @SystemEndTime DATETIME
	DECLARE @LotteryID INT
	declare @PrintOutType smallint
	declare @IsOpened bit
	
	set @Isuse = null
	select @LotteryID = LotteryID,@IsOpened = IsOpened, @Code = [Code], @Isuse = [Name], @StartTime = StartTime, @SystemEndTime = dbo.F_GetIsuseSystemEndTime([ID], @PlayTypeID), @PrintOutType = PrintOutType from T_Lottery_Isuses where [ID] = @IsuseID

	if @Isuse is null
	begin
		set @SchemeID = -1
		set @ReturnDescription = '期号不存在'

		return
	end

	if not (datediff(mi,GetDate(),@SystemEndTime)>=0)
	begin
		set @SchemeID = -2
		set @ReturnDescription = '该期已截止'

		return
	end
	
	if @IsOpened = 1
	begin
		set @SchemeID = -14
		set @ReturnDescription = '该期已开奖'

		return	
	end

	declare @Opt_InitiateSchemeLimitLowerScaleMoney money
	declare @Opt_InitiateSchemeLimitLowerScale money
	declare @Opt_InitiateSchemeLimitUpperScaleMoney float
	declare @Opt_InitiateSchemeLimitUpperScale float

	declare @Opt_InitiateSchemeMaxNum int
	declare @Opt_InitiateFollowSchemeMaxNum int
	declare @Opt_SchemeMinMoney money
	declare @Opt_SchemeMaxMoney money

	select @Opt_InitiateSchemeLimitLowerScaleMoney = Opt_InitiateSchemeLimitLowerScaleMoney, @Opt_InitiateSchemeLimitLowerScale = Opt_InitiateSchemeLimitLowerScale,
		@Opt_InitiateSchemeLimitUpperScaleMoney = Opt_InitiateSchemeLimitUpperScaleMoney, @Opt_InitiateSchemeLimitUpperScale = Opt_InitiateSchemeLimitUpperScale,
		@Opt_InitiateSchemeMaxNum = Opt_InitiateSchemeMaxNum, @Opt_InitiateFollowSchemeMaxNum = Opt_InitiateFollowSchemeMaxNum,
		@Opt_SchemeMinMoney = Opt_SchemeMinMoney, @Opt_SchemeMaxMoney = Opt_SchemeMaxMoney from T_System_Params

	declare @InitiateSchemeCount int
	select @InitiateSchemeCount = isnull(count(*), 0) from T_Lottery_Schemes where InitiateUserID = @UserID and IsuseID = @IsuseID and Share > 1

	if (@InitiateSchemeCount >= @Opt_InitiateSchemeMaxNum)
	begin
		set @SchemeID = -5
		set @ReturnDescription = '每人每期最多只能发起 ' + cast(@Opt_InitiateSchemeMaxNum as varchar(20)) + ' 个方案'

		return
	end

	if (@Money < @Opt_SchemeMinMoney)
	begin
		set @SchemeID = -7
		set @ReturnDescription = '单个方案金额必须不低于 2 块'

		return
	end
	
	declare @Balance money
	declare @CardpassWord money
	declare @CardPasswordMony money
	declare @CardPasswordLotteryMoney money
	declare @BuyMoney money
	declare @isAlipayNameValided bit
	declare @IsEmailValided bit
	declare @IsMobileValided bit
	
	set @BuyMoney = (@Money / @Share) * @BuyShare
	set @Balance = null
	select @Balance = Balance,@CardpassWord = CardpassWord, @isAlipayNameValided = isAlipayNameValided, @IsEmailValided = isEmailValided,@IsMobileValided = isMobileValided from T_User_Balance where [UserId] = @UserID

	if @Balance is null
	begin
		set @SchemeID = -8
		set @ReturnDescription = '用户不存在'

		return
	end
	
	if(@CardpassWord > 0)
	begin
		select @CardPasswordMony = (isnull([Money], 0) - isnull(MoneyUse, 0)) from T_CardPasswordDetails where UserID = @UserID and LotteryID = @LotteryID
		
		if @CardPasswordMony is null
		begin
			set @CardPasswordMony = 0
		end
		
		if(@CardPasswordMony > (@BuyMoney + @AssureMoney))
		begin
			update T_CardPasswordDetails set MoneyUse = MoneyUse + @BuyMoney + @AssureMoney where UserID = @UserID and LotteryID = @LotteryID
		end
		else if (@CardPasswordMony > 0)
		begin
			update T_CardPasswordDetails set MoneyUse = MoneyUse + @CardPasswordMony where UserID = @UserID and LotteryID = @LotteryID
		end
		
		select @CardPasswordLotteryMoney = (isnull([Money], 0) - isnull(MoneyUse, 0)) from T_CardPasswordDetails where UserID = @UserID and LotteryID <> @LotteryID
		
		if @CardPasswordLotteryMoney is null
		begin
			set @CardPasswordLotteryMoney = 0
		end
	end
	
	if @Balance < (@BuyMoney + @AssureMoney)
	begin
		if(@Balance + @CardpassWord < @BuyMoney + @AssureMoney)
		begin
			set @SchemeID = -9
			set @ReturnDescription = '用户账户余额不足'

			return
		end
		else if(@Balance -@CardPasswordLotteryMoney + @CardPasswordMony < @BuyMoney + @AssureMoney)
		begin
			set @SchemeID = -10
			set @ReturnDescription = '电子优惠卷只能用于购买指定的彩种'

			return
		end
		else
		begin
		    declare @CardpassWordToBalance money
		    set @CardpassWordToBalance = @BuyMoney + @AssureMoney - @Balance
		    exec P_CardPasswordToBalance @UserID,@CardpassWordToBalance
		end
	end

	declare @Opt_InitiateSchemeLimitScale float
	set @Opt_InitiateSchemeLimitScale = 0

	if ((@Opt_InitiateSchemeLimitLowerScaleMoney > 0) and (@Opt_InitiateSchemeLimitUpperScaleMoney > @Opt_InitiateSchemeLimitLowerScaleMoney) and (@Opt_InitiateSchemeLimitUpperScale > 0) and (@Opt_InitiateSchemeLimitLowerScale > @Opt_InitiateSchemeLimitUpperScale))
	begin
		if (@Money <= @Opt_InitiateSchemeLimitLowerScaleMoney)
		begin
			set @Opt_InitiateSchemeLimitScale = @Opt_InitiateSchemeLimitLowerScale;
		end
		else if (@Money >= @Opt_InitiateSchemeLimitUpperScaleMoney)
		begin
			set @Opt_InitiateSchemeLimitScale = @Opt_InitiateSchemeLimitUpperScale;
		end
		else
		begin
			set @Opt_InitiateSchemeLimitScale = @Opt_InitiateSchemeLimitLowerScale - ((@Money - @Opt_InitiateSchemeLimitLowerScaleMoney) * ((@Opt_InitiateSchemeLimitLowerScale - @Opt_InitiateSchemeLimitUpperScale) / (@Opt_InitiateSchemeLimitUpperScaleMoney - @Opt_InitiateSchemeLimitLowerScaleMoney)))
		end
	end
	else if (@Opt_InitiateSchemeLimitLowerScale = @Opt_InitiateSchemeLimitUpperScale)
	begin
		set @Opt_InitiateSchemeLimitScale = @Opt_InitiateSchemeLimitLowerScale
	end

	if (@Opt_InitiateSchemeLimitScale <= 0)
	begin
		set @Opt_InitiateSchemeLimitScale = 0.1
	end

	declare @ShareMoney money
	declare @AssureShare int

	set @ShareMoney = @Money / @Share
	set @AssureShare = round(@AssureMoney / @ShareMoney, 0)

	if (@BuyShare < round(@Share * @Opt_InitiateSchemeLimitScale, 0))
	begin
		set @SchemeID = -11
		set @ReturnDescription = '此方案最少必须认购 ' + cast(@Opt_InitiateSchemeLimitScale * 100 as varchar(20))+ '%。(' + cast(round(@Share * @Opt_InitiateSchemeLimitScale, 0) as varchar(20)) + '份)'

		return
	end

	if ((@BuyShare + @AssureShare) > @Share)
	begin
		set @SchemeID = -12
		set @ReturnDescription = '保底和购买的份数大于总份数'

		return
	end
	if(@SchemeBonusScale * 100 > 10 )
	begin
		set @SchemeID = -13
		set @ReturnDescription = '佣金比例不能高于10%'

		return
	end
	-- 写入方案
	insert into T_Lottery_Schemes (Title, [Description], InitiateUserID, IsuseID, PlayTypeID, LotteryNumber, UploadFileContent, 
		Multiple, [Money], AssureMoney, Share, SecrecyLevel, BuyedShare, Schedule, ReSchedule,SchemeBonusScale)
		values (@Title, @Description, @UserID, @IsuseID, @PlayTypeID, @LotteryNumber, @UploadFileContent,
		@Multiple, @Money, @AssureMoney, @Share, @SecrecyLevel, @BuyShare, ROUND(CAST(@BuyShare AS float) / @Share * 100, 2), (case when @BuyShare >= @Share then 0 else ROUND(CAST(@BuyShare AS float) / @Share * 100, 2) end),@SchemeBonusScale)
	select @SchemeID = SCOPE_IDENTITY()
	
	insert into T_SchemesNumber (SchemeID, LotteryNumber, [Money], Multiple) values (@SchemeID, @LotteryNumber, @Money, @Multiple)

	declare @ReturnValue_2 int
	declare @ReturnDescript_2 varchar(100)

	-- 写入招股对象
	if (@OpenUsers <> '')
	begin
		exec dbo.P_SetSchemeOpenUsers @SiteID, @SchemeID, @OpenUsers, @ReturnValue_2 output, @ReturnDescript_2 output
	end

	-- 根据 SchemeID 计算 SchemeNumber
	set @SchemeNumber = @Isuse + @Code + cast(@SchemeID as varchar(20))
	update T_Schemes set SchemeNumber = @SchemeNumber where [ID] = @SchemeID
	
	-- 写发起人保底
	if @AssureMoney <> 0
	begin
		update T_Users set Balance = Balance - @AssureMoney, Freeze = Freeze + @AssureMoney where [ID] = @UserID
		insert into T_UserDetails (SiteID, UserID, OperatorType, [Money], SchemeID) values (@SiteID, @UserID, dbo.F_GetDetailsOperatorType('保底冻结'), @AssureMoney, @SchemeID)
	end

	-- 写发起人购买账务
	insert into T_BuyDetails (SiteID, UserID, SchemeID, Share, isWhenInitiate,DetailMoney) values (@SiteID, @UserID, @SchemeID, @BuyShare, 1,@BuyMoney)

	update T_Users set Balance = Balance - @BuyMoney where [ID] = @UserID
	insert into T_UserDetails (SiteID, UserID, OperatorType, [Money], SchemeID) values (@SiteID, @UserID, dbo.F_GetDetailsOperatorType('购买'), @BuyMoney, @SchemeID)

	if exists(select 1 from T_Schemes where ID = @SchemeID and Schedule >= 100)
	begin
		if exists (select 1 from T_UserBySchemes where UserID = @UserID)
		begin
			exec P_SchemePrintOut 1, @SchemeID, 1, @PrintOutType, '', 1, @ReturnValue_2 output, @ReturnDescript_2 output
		end
	end
	else
	begin
		if exists (select 1 from T_UserBySchemes where UserID = @UserID)
		begin
			set @SchemeID = -14
			set @ReturnDescription = '发起合买方案失败'
			
			return
		end
	end
	
	if(@CardPasswordMony > 0)
	begin
		if(@PlayTypeID <> 6101)
		begin
			exec P_SchemePrintOut 1, @SchemeID, 1, @PrintOutType, '', 1, @ReturnValue_2 output, @ReturnDescript_2 output
		end
		else if(CHARINDEX('-', @LotteryNumber) > 0)
		begin
			exec P_SchemePrintOut 1, @SchemeID, 1, @PrintOutType, '', 1, @ReturnValue_2 output, @ReturnDescript_2 output
		end
	end

	declare @Cur cursor
	declare @FollowSchemesUserID bigint
	declare @FollowSchemesMoney money
	declare @FollowSchemesShare int
	declare @RemainingShare int			-- 剩余份数
	declare @RemainingMoney money		-- 剩余金额
	declare @FollowUserBalance money	-- 跟单人剩余金额
	declare @BuyShareStart int
	declare @BuyShareEnd INT
	declare @MoneyStart money
	declare @MoneyEnd money

	set @RemainingShare = @Share - @BuyShare
	set @RemainingMoney = @Money - @BuyMoney
	
	-- 好友自动定制跟单
	IF(@RemainingShare > 0)
	BEGIN
		set @Cur = cursor FAST_FORWARD for select UserID, MoneyStart, MoneyEnd, BuyShareStart, BuyShareEnd from T_CustomFriendFollowSchemes
			where [SiteID] = @SiteID and FollowUserID = @UserID
			and MoneyStart <= MoneyEnd AND BuyShareStart <= BuyShareEnd
			AND MoneyStart >= 1 AND BuyShareStart >= 1
			AND (LotteryID = @LotteryID OR LotteryID = -1) AND (PlayTypeID = @PlayTypeID OR PlayTypeID = -1)
		open @Cur

		fetch next from @Cur into @FollowSchemesUserID, @MoneyStart, @MoneyEnd, @BuyShareStart, @BuyShareEnd
		while @@fetch_status = 0 and @RemainingShare > 0
		BEGIN
			IF(@ShareMoney * @BuyShareStart > @MoneyEnd)
			BEGIN
				fetch next from @Cur into @FollowSchemesUserID, @MoneyStart, @MoneyEnd, @BuyShareStart, @BuyShareEnd 
				CONTINUE
			END
			
			IF(@ShareMoney * @BuyShareEnd >= @MoneyEnd)
			BEGIN
				set @FollowSchemesMoney = @MoneyEnd
			END
			ELSE
			BEGIN
				set @FollowSchemesMoney = @ShareMoney * @BuyShareEnd
			END
			
			IF(@FollowSchemesMoney > @RemainingMoney)
			BEGIN
				set @FollowSchemesMoney = @RemainingMoney
			END
			
			IF(@RemainingMoney < @BuyShareStart)
			BEGIN
				fetch next from @Cur into @FollowSchemesUserID, @MoneyStart, @MoneyEnd, @BuyShareStart, @BuyShareEnd 
				CONTINUE
			END

			select @FollowUserBalance = Balance from T_Users where [ID] = @FollowSchemesUserID and RealityName <> '' 

			if ((@FollowUserBalance is null) or (@FollowUserBalance < @FollowSchemesMoney))
			BEGIN
				fetch next from @Cur into @FollowSchemesUserID, @MoneyStart, @MoneyEnd, @BuyShareStart, @BuyShareEnd 
				CONTINUE
			END

			set @FollowSchemesShare = @FollowSchemesMoney / @ShareMoney

			exec [dbo].[P_JoinScheme] @SiteID, @FollowSchemesUserID, @SchemeID, @FollowSchemesShare, 1, @ReturnValue_2 output, @ReturnDescription output

			if (@ReturnValue_2 < 0)
			BEGIN
				fetch next from @Cur into @FollowSchemesUserID, @MoneyStart, @MoneyEnd, @BuyShareStart, @BuyShareEnd 
				CONTINUE
			END
			
			set @RemainingMoney = @RemainingMoney - @FollowSchemesMoney
			set @RemainingShare = @RemainingShare - @FollowSchemesShare
			
			fetch next from @Cur into @FollowSchemesUserID, @MoneyStart, @MoneyEnd, @BuyShareStart, @BuyShareEnd 
		END
		
		close @Cur
	END
	
	set @ReturnDescription = ''
END

