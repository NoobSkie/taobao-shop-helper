// 页面中的块
TemplateBlock = function() {
    this.Id;
    this.ParentId;
    this.ParentBlock;
    this.DataType;
    this.DisplayName;
    this.DefaultValue;
    this.ShowTitle = true;
    this.IsFloat = true;
    this.TitleWidth = 0;
    this.InputWidth = 0;
    this.InputHeight = 0;

    this.Dom;

    this.Create = function() {
        var dom = document.createElement("div");
        dom.className = "TemplateBlock";
        this.Dom = dom;
    }
}

// 模板块 - 列表类型
TemplateBlock_List = function() {
    this.Id;
    this.ParentId;
    this.ParentBlock;
    this.DataType = new String();
    this.DisplayName = new String();
    this.DefaultValue = new String();

    this.ChildrenItem = new Array();
    this.ModuleItem = new TemplateBlock_Children();

    this.Dom;
    this.ContentDom;

    this.Create = function() {
        var dom = document.createElement("div");
        dom.className = "ListBlock";
        if (this.ParentId == -1) {
            dom.className += " TemplateBlock";
        }

        var header = document.createElement("div");
        header.className = "BlockHeader";
        var title = document.createElement("span");
        title.className = "Title";
        title.innerHTML = this.DisplayName;
        header.appendChild(title);
        var add = document.createElement("a");
        add.className = "AddNew";
        add.innerHTML = "添加";
        add.href = "javascript:void(0);";
        add.attachEvent("onclick", this.AddChildrenBlock(this));
        header.appendChild(add);
        dom.appendChild(header);

        var content = document.createElement("div");
        content.className = "BlockContent";
        dom.appendChild(content);
        this.ContentDom = content;

        var footer = document.createElement("div");
        footer.className = "BlockFooter";
        dom.appendChild(footer);

        this.Dom = dom;
    }

    this.SetDefaultValue = function() {
        var flag = false;
        if (this.DefaultValue && this.DefaultValue != "") {
            var values = this.DefaultValue.split(",");
            for (var i = 0; i < values.length; i++) {
                var value = values[i];
                var childrenItem = this.ModuleItem.Clone();
                childrenItem.DefaultValue = value;
                if (childrenItem.SetDefaultValue()) {
                    childrenItem.Create(true);
                    this.ChildrenItem.push(childrenItem);
                    this.ContentDom.appendChild(childrenItem.Dom);

                    flag = true;
                }
            }
        }
        return flag;
    }

    this.AddChildrenBlock = function(parentBlock) {
        return function() {
            parentBlock.CreateChildren(false);
        }
    }

    this.AddChild = function(block) {
        this.ModuleItem.AddChild(block);
    }

    this.CreateChildren = function(isDefault) {
        var childrenItem = this.ModuleItem.Clone();
        childrenItem.Create(isDefault);
        this.ChildrenItem.push(childrenItem);
        this.ContentDom.appendChild(childrenItem.Dom);
    }

    this.GetJsonString = function() {
        var json = new String();
        json = "[";
        for (var i = 0; i < this.ChildrenItem.length; i++) {
            if (i != 0) {
                json += ",";
            }
            var child = this.ChildrenItem[i];
            json += child.GetJsonString();
        }
        json += "]";
        return json;
    }
}

TemplateBlock_Children = function() {
    this.Id;
    this.ParentId;
    this.ParentBlock;
    this.DataType = new String();
    this.DefaultValue = new String();

    this.ChildrenItem = new Array();

    this.Dom;

    this.Clone = function() {
        var block = new TemplateBlock_Children();
        if (this.ChildrenItem) {
            block.ChildrenItem = new Array();
            for (var i = 0; i < this.ChildrenItem.length; i++) {
                block.ChildrenItem[i] = this.ChildrenItem[i];
            }
        }
        if (this.Dom) {
            block.Dom = this.Dom.cloneNode();
        }
        return block;
    }

    this.Create = function(isDefault) {
        this.Dom = document.createElement("div");
        this.Dom.className = "ChildrenBlock";
        for (var i = 0; i < this.ChildrenItem.length; i++) {
            var item = this.ChildrenItem[i];
            item.Create(isDefault);
            this.Dom.appendChild(item.Dom);
        }
    }

    this.SetDefaultValue = function() {
        var flag = false;
        if (this.DefaultValue && this.DefaultValue != "") {
            var items = this.DefaultValue.split("#");
            if (items.length == this.ChildrenItem.length) {
                for (var j = 0; j < this.ChildrenItem.length; j++) {
                    var child = this.ChildrenItem[j];
                    child.DefaultValue = items[j];
                }
                flag = true;
            }
        }
        return flag;
    }

    this.AddChild = function(block) {
        this.ChildrenItem.push(block);
    }

    this.GetJsonString = function() {
        var json = new String();
        json = "[";
        for (var i = 0; i < this.ChildrenItem.length; i++) {
            if (i != 0) {
                json += ",";
            }
            var child = this.ChildrenItem[i];
            json += child.GetJsonString();
        }
        json += "]";
        return json;
    }
}

// 模板块 - 单项类型
TemplateBlock_Item = function() {
    this.Id;
    this.CurrentValue = new String();
    this.ParentId;
    this.ParentBlock;
    this.DataType = new String();
    this.DisplayName = new String();
    this.DefaultValue = new String();
    this.ShowTitle = true;
    this.IsFloat = true;
    this.TitleWidth = 0;
    this.InputWidth = 0;
    this.InputHeight = 0;

    this.Dom;
    this.ContentCtrl;

    this.GetJsonString = function() {
        var json = new String();
        json = "{\"value\":\"" + this.CurrentValue + "\"}";
        return json;
    }

    this.Create = function(isDefault) {
        var dom = document.createElement("div");
        dom.className = "ItemBlock";
        if (this.ParentId == -1) {
            dom.className += " TemplateBlock";
        }
        if (this.ShowTitle) {
            dom.appendChild(this.CreateCtrl_Span("Title", this.DisplayName));
        }
        var ctrl;
        switch (this.DataType.toLowerCase()) {
            case "text":
                ctrl = this.CreateCtrl_Input("ItemContent", this.DefaultValue, isDefault);
                break;
            case "imageurl":
                ctrl = this.CreateCtrl_ImageUrl("ItemContent", this.DefaultValue, isDefault);
                break;
        }
        if (ctrl) {
            dom.appendChild(ctrl);
            this.ContentCtrl = ctrl;
        }
        if (this.IsFloat) {
            dom.className += " FloatLeft";
        }
        this.Dom = dom;
    }

    this.CreateCtrl_ImageUrl = function(cssName, text, hasValue) {
        var container = document.createElement("div");
        var ctrl = document.createElement("input");
        ctrl.type = "text";
        ctrl.attachEvent("onchange", this.ChangeInput(ctrl, this));
        if (hasValue) {
            ctrl.value = text;
            this.CurrentValue = ctrl.value;
        }
        ctrl.className = cssName;
        if (this.InputWidth > 0) {
            ctrl.style.width = this.InputWidth;
        }
        container.appendChild(ctrl);
        //        var search = document.createElement("a");
        //        search.href = "javascript:void(0);";
        //        search.innerHTML = "选择";
        //        container.appendChild(search);
        return container;
    }

    this.CreateCtrl_Input = function(cssName, text, hasValue) {
        var ctrl = document.createElement("input");
        ctrl.type = "text";
        ctrl.attachEvent("onchange", this.ChangeInput(ctrl, this));
        if (hasValue) {
            ctrl.value = text;
            this.CurrentValue = ctrl.value;
        }
        ctrl.className = cssName;
        if (this.InputWidth > 0) {
            ctrl.style.width = this.InputWidth;
        }
        return ctrl;
    }

    this.ChangeInput = function(ctrl, block) {
        return function() {
            block.CurrentValue = ctrl.value;
        }
    }

    this.CreateCtrl_Span = function(cssName, text) {
        var ctrl = document.createElement("span");
        ctrl.innerHTML = text;
        ctrl.className = cssName;
        if (this.TitleWidth > 0) {
            ctrl.style.width = this.TitleWidth;
        }
        return ctrl;
    }
}

