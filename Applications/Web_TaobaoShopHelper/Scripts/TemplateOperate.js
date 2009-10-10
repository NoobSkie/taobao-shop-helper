// 初始化模板容器
TemplateHelper = function() {
    // 当前模板容器
    this.CurrentTemplateContainer;
    // 已加载加载的块列表
    this.TemplateBlockList;

    this.InitContainer = function(containerDiv) {
        this.CurrentTemplateContainer = containerDiv;
        this.TemplateBlockList = new Array();
    }

    this.GetBlockById = function(id) {
        for (var i = 0; i < this.TemplateBlockList.length; i++) {
            var block = this.TemplateBlockList[i];
            if (block.Id == id) {
                return block;
            }
        }
        return null;
    }

    this.GetTopBlocks = function() {
        var blocks = new Array();
        for (var i = 0; i < this.TemplateBlockList.length; i++) {
            var block = this.TemplateBlockList[i];
            if (block.ParentId == -1) {
                blocks.push(block);
            }
        }
        return blocks;
    }

    this.GetJsonString = function() {
        var json = new String();
        for (var i = 0; i < this.TemplateBlockList.length; i++) {
            var block = this.TemplateBlockList[i];
            json += block.GetJsonString();
        }
        return json;
    }

    this.SetDefaultValue = function() {
        var flag = false;
        for (var i = 0; i < this.TemplateBlockList.length; i++) {
            var block = this.TemplateBlockList[i];
            if (block.SetDefaultValue && block.SetDefaultValue()) {
                flag = true;
            }
        }
        return flag;
    }

    this.AddTemplateBlock_List = function(index, title, category, dataType, defaultValue, parentId) {
        var parentBlock = this.GetBlockById(parentId);
        var block = new TemplateBlock_List();
        block.Id = index;
        block.ParentId = parentId;
        block.ParentBlock = parentBlock;
        block.DataType = dataType;
        block.DisplayName = title;
        block.DefaultValue = defaultValue;

        if (parentBlock) {
            parentBlock.AddChild(block);
            parentBlock.ChildrenItem.push(block);
        }
        else {
            block.Create();
            this.CurrentTemplateContainer.appendChild(block.Dom);
            this.TemplateBlockList.push(block);
        }
    }

    this.AddTemplateBlock_Item = function(index, title, category, dataType, defaultValue, showTitle, isFloat, titleWidth, inputWidth, inputHeight, parentId) {
        var parentBlock = this.GetBlockById(parentId);
        var block = new TemplateBlock_Item();
        block.Id = index;
        block.ParentId = parentId;
        block.ParentBlock = parentBlock;
        block.DataType = dataType;
        block.DisplayName = title;
        block.DefaultValue = defaultValue;
        block.ShowTitle = showTitle;
        block.IsFloat = isFloat;
        block.TitleWidth = titleWidth;
        block.InputWidth = inputWidth;
        block.InputHeight = inputHeight;

        if (parentBlock) {
            parentBlock.AddChild(block);
            parentBlock.ChildrenItem.push(block);
        }
        else {
            block.Create();
            this.CurrentTemplateContainer.appendChild(block.Dom);
            this.TemplateBlockList.push(block);
        }
    }
}