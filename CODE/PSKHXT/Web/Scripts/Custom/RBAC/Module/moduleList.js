var moduleList = {
    //查询url
    searchUrl: "",
    addUrl: "",
    editUrl: "",
    table: $("#tableModules"),
    btnAdd: $("#btnAdd"),
    btnEdit: $("#btnEdit"),
    btnSearch: $("#btnSearch"),
    btnSave: $("#btnSaveOfModalForm"),
    txtSearchModuleName: $("#txtSearchModuleName"),
    ddlSearchModuleEnable: $("#ddlSearchModuleEnable"),
    //获取查询参数
    searchParams: function (params) {
        var temp = {
            limit: params.limit,//页大小
            offset: params.offset,//偏移量（起始位置）
            moduleName: moduleList.txtSearchModuleName.val(),
            enable: moduleList.ddlSearchModuleEnable.val()
        };
        return temp;
    },
    //列表列
    tbCols: [
                { checkbox: true },
                {
                    title: '序号',
                    align: 'center',
                    formatter: function (value, row, index) {
                        return tableHelper.m_pagerow + index + 1;
                    }
                },
                { field: 'Id', title: 'Id', visible: false },
                { field: 'Name', title: '模块名称' },
                { field: 'ParentName', title: '上级模块' },
                { field: 'Code', title: '编号' },
                { field: 'LinkUrl', title: '链接地址' },
                { field: 'Description', title: '描述' },
                { field: 'StrIsMenu', title: '是否菜单' },
                { field: 'StrUpdateDate', title: '更新时间' },
                {
                    field: 'StrEnabled',
                    title: '是否激活',
                    align: 'center',
                    cellStyle: function (value, row, index) {
                        if (value === '否') {
                            return {
                                css: { "color": "red" }
                            };
                        } else {
                            return {};
                        }
                    }
                }
    ],
    init: function (param) {
        moduleList.searchUrl = param.searchUrl;
        moduleList.addUrl = param.addUrl;
        moduleList.editUrl = param.editUrl;
        //初始化列表
        tableHelper.InitTable(moduleList.table, moduleList.searchUrl, moduleList.searchParams, moduleList.tbCols);
        //绑定按钮事件
        moduleList.bindEvent();
    },
    bindEvent: function () {
        //新增
        moduleList.btnAdd.click(function () {
            modalFormHelper.showModal(moduleList.addUrl, {}, '新增模块');
        });
        //编辑
        moduleList.btnEdit.click(function () {
            var selRows = moduleList.table.bootstrapTable('getSelections');
            if (selRows.length > 1) {
                toastr.warning('只能选择一行进行编辑');
                return;
            }
            if (selRows.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }
            modalFormHelper.showModal(moduleList.editUrl, { id: selRows[0].Id }, '修改模块');
        });
        //保存
        moduleList.btnSave.click(function () {
            modalFormHelper.saveModal(moduleList.table);
        });
        //查询
        moduleList.btnSearch.click(function () {
            moduleList.table.bootstrapTable('refresh', { url: moduleList.searchUrl });
        });
    }
};