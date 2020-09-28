//var UsuariosSystem = []

function DeleteData(ID) {
    //render product
    alert(ID);   
    $("datatable tbody").parents('tr').remove();
    var target_row = $(this).closest('tr').get(0);

    alert('Delete this id ' + target_row);

    //$.ajax({
    //    type: "GET",
    //    url: "/Order/EliminarPedido",
    //    data: { 'idDocumento': parseInt(ID)},
    //    success: function (data) {
    //        //render products to appropriate dropdown
    //        alert('Pedido Eliminado');
    //    },
    //    error: function (error) {
    //        console.log(error);
    //    }
    //});
}


$(document).ready(function () {
   // var tableObj = $('#datatable').DataTable();

    Jquery102('#datatable tbody').on('click', 'tr td #del', function () {
              
        var $row = $(this).closest('tr');
        
        //var ID = $row.find('td:eq(1)').html();
        //var ID2 = $row.find('td:eq(0)').attr('href');
        var ID = $row.find('td:eq(0)').text();          
        var con = confirm("Desea eliminar el pedido?");
        if (con) {      
            Jquery102("#loaderDiv").show();


            $.ajax({
                type: "POST",
                url: "/Order/EliminarPedido",
                data: { 'idDocumento': parseInt(ID) },
                success: function (data) {
                    if (data.status) {
                     //   alert('Successfully saved');                     
                        alert('Pedido Eliminado');
                    }
                    //render products to appropriate dropdown
                    
                },
                error: function (error) {
                    console.log(error);
                    $("#loaderDiv").hide();
                }
            });
            Jquery102(this).parents('tr').remove();
            Jquery102("#loaderDiv").hide();
        }
        else {
        }      
        //var mydata = (tableObj.row(row).data());
        //alert(mydata["idDocumento"]);
        


    });

    //$('#datatable tbody').on('click', 'img.icon-delete', function () {
    //    table
    //        .row($(this).parents('tr'))
    //        .remove()
    //        .draw();
    //});

    // Delete a record
    //$('#datatable').on('click', 'a.editor_remove', function (e) {
    //    e.preventDefault();

    //    editor.remove($(this).closest('tr'), {
    //        title: 'Delete record',
    //        message: 'Are you sure you wish to remove this record?',
    //        buttons: 'Delete'
    //    });
    //});

    //$('#datatable tbody').on('click', 'a.delete', function () {
    //    table
    //        .row($(this).parents('tr'))
    //        .remove()
    //        .draw();
    //});

    //$('#datatable tbody').on('click', 'tr', function () {
    //    var row = $('#datatable tbody').row($(this).parents('tr'));
    //    var rowNode = row.node();
    //    row.remove();
    //});

    //$('#datatable tbody').on('click', 'tr', function () {
    //    var myTable = $('#myTable').DataTable();
    //    alert("dd");
    //    myTable.row(this)
    //    $('#datatable').DataTable().row(this).de;
    //    $('#datatable').DataTable().row($(this).parents('tr')).remove();
        
    ////        .remove();
    //});

    //$('#datatable tbody').on('click', 'tr', function () {
    //    $('#datatable').DataTable()
    //        .row($(this).parents('tr'))
    //        .remove()
    //        .draw();
    //});

    

    Jquery102('#btnConsultar').click(function () {
        //alert('script ordenes');
        var mes = $('#cboMes').val();
        var anio = $('#textAnio').val();

        if (mes == "-1") {
            alert('Debe seleccionar un mes válido!');
            return;
        }
   //     $("#loaderDiv").show();

    //    var youngsters2 = UsuariosSystem.filter(p => p.idUsuario == 21230);

        //var o = Object(youngsters2);
        //var content = JSON.stringify(o);
        //var obj = JSON.parse(content);
        ////alert(content);        
        //alert(obj[0].full_Name);
        var data = { 'mes': mes, "anio": anio };

        Jquery102('#datatable').DataTable({            
            destroy: true,
            paging: true,
            searching: true,
            responsive: true,
            language: {
                sLoadingRecords: '<span style="width:100%;"><img src="http://www.snacklocal.com/images/ajaxload.gif"></span>'
            },    
            "order": [[0, 'desc']],
            "ajax": {
                "url": "/Order/LoadOrders",
                "type": "GET",
                "data": data,
                "datatype": "json"
            },
            "columns": [
                {                    
                    "data": "idDocumento", 'render': function (webSite) {
                        if (!webSite) {
                            return 'N/A';
                        }
                        else {
                            return '<a href=' + webSite + 'id=id>'
                                + webSite + '</a>';
                        }
                    }
                },
                {
                    "data": "fechaDoc", 'render': function (jsonDate) {
                        var date = new Date(parseInt(jsonDate.substr(6)));
                        var month = date.getMonth() + 1;
                        return date.getDate() + "/" + month + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                    }
                },
                {
                    "data": "usuarioActualizacion", "autoWidth": true, 'render': function (vendedor) {
                        if (!vendedor) {                         
                            return 'N/A';
                        }
                        else {
                            var vend = UsuariosSystem.filter(p => p.idUsuario == vendedor);
                            var o = Object(vend);
                            var content = JSON.stringify(o);
                            var obj = JSON.parse(content);                
                            var nombre = obj[0].full_Name;
                            return nombre;
                        }
                    }
                },
                { "data": "numeroVenta", "autoWidth": true },
                { "data": "NombreEntidad", "autoWidth": true },
                { "data": "NroDocEntidad", "autoWidth": true },
                { "data": "moneda", "autoWidth": true },
                {
                    "data": "ImporteNacional", className: 'dt-body-right', render: Jquery102.fn.dataTable.render.number(',', '.', 2)
                    //"data": "ImporteNacional", className: 'dt-body-right', render: function (data, type, row) {
                    //    return $.fn.dataTable.render.number(',', '.', 2)
                    //} 
                    

                },
                {
                    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Order/Edit/' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                      //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-danger" id=del> <span class="glyphicon glyphicon-trash"></span> </a>';
                    }
                },
            ]
        })
    //    $("#loaderDiv").hide();
    });

    $('#btnNuevo').click(function () {
     //   alert('btn nuevo');
        //var url = '@Url.Action("NuevaOrden", "Order")';
        window.location.href = 'NuevaOrden';
    });

    
});