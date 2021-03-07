IM = window.IM || {};

(function (namespace) {
    namespace.Inventory = Inventory;
    var proto = Inventory.prototype;
    var obj;

    function Inventory(options) {      
        obj = options;
        $("#pnlInventory").togglepanels();
        this.BindDataAndEvents();
      
    }

    proto.BindDataToTable = function (list) {

        $.jgrid.gridUnload("#grid");
        $("#grid").jqGrid({
            datatype: "jsonstring",
            datastr: list,
            height: 'auto',
            recordpos: 'left',
            //width: 'auto',
            //autowidth: true,
            rowNum: 20,
            viewrecords: true,
            rowList: [20, 50, 100],
            pager: '#pager',
            recordtext: "View {0} - {1} of {2}",
            cmTemplate: { sortable: false },
            colNames: ['Name', 'Description', 'Price',''],

            colModel: [
                //{
                //    name: 'ID',
                //    index: 'ID',
                //    width: '50',
                //    align: 'center',
                //    formatter: function (cellValue, option, rowObject) {
                //        debugger;
                //        return "<input id='chk_" + option.rowId + "' type='checkbox'  InventID ='" + rowObject.Id + "' />";
                //    }
                //},                             
                {
                    name: 'Name',
                    index: 'Name',
                    width: 120,
                    sorttype: "string",
                        formatter: function (cellValue, option, rowObject) {                           
                            return option.rowId.indexOf("_") !== -1 ? "" : (rowObject.Id !== null || rowObject.Id !== '' ? "<a href='" + obj.LoadInvenURL + "/" + rowObject.Id + "' id='lnk_" + option.rowId.toString() + "'title='Click the Name to view details'  style='color:#004b8d;' target='_blank'>" + cellValue + "</a>" : cellValue);
                    }
                },
                {
                    name: 'Description',
                    index: 'Description',
                    width: 250,
                    sorttype: "string"
                },
                {
                    name: 'Price',
                    index: 'Price',
                    width: 250
                },
                {
                    name: '',
                    index: '',
                    width: '100',
                    align: 'center',
                    formatter: function (cellValue, option, rowObject) {
                       
                        return "<a style='color:red' title='delete' href='#' onclick='$.App.Inventory.Delete(\"" + rowObject.Id + "\")'><u>delete</u></a>";
                    }
                }  
            ]
        });
    }

    proto.BindDataAndEvents = function () {
        var obj = this;

        obj.LoadDataIntoTable();

        $("#btnSubmit").click(function () {           
            if ($("#txtname").val() === "" || $("#txtprice").val() === "") {
                alert("Enter Manadtory Fields");
                return true;
            }
           
            var fileUpload = $("#Files").get(0);
            var files = fileUpload.files;  //fileUpload.files;           
            // Create FormData object    
            var fileData = new FormData();
            // Looping over all files and add it to FormData object    
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }

            var inventory = {
                Name: $("#txtname").val(),
                Description: $("#txtdescription").val() === "" ? "" : $("#txtdescription").val(),
                Price: $("#txtprice").val(),
                Picture: ""
            };

            $.ajax({

                type: "PUT",
                url: InventoryAPI + "SaveInventory",
                data: JSON.stringify(inventory),
                dataType: "json",
                contentType: "application/json; charset-utf-8",
                success: function (jsondata, stat) {
                    if (stat === "success") {                        
                        obj.LoadDataIntoTable();
                        alert("Data Saved Successfully");
                    }
                }
            });

        });
        
    }; 

    proto.LoadDataIntoTable = function () {
        var obj = this;  
        $.ajax({
            type: "GET",
            url: InventoryAPI + "GetInventoryList",
            data: "json",
            contentType: "application/json; charset-utf-8",
            success: function (jsondata, stat) {
                if (stat === "success") {
                    var JsonData = $.parseJSON(jsondata);
                    obj.BindDataToTable(JsonData.InventList)
                }
            }

        });
    }

    proto.Delete = function (id) {
        var obj = this;      

        if(confirm("Do you want to delete?"))
        {
            $.ajax({

                type: "delete",
                url: InventoryAPI + "DeleteInventoryById?id=" + id,
                dataType: "json",
                contentType: "application/json; charset-utf-8",
                success: function (jsondata, stat) {                   
                    obj.LoadDataIntoTable();
                    alert("Record Deleted Successfully");
                }
            });
        }              
    }
   
})(IM);