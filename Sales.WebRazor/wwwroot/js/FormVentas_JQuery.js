
var num = 0;
var modo = 0;
var num_edit = 0;

function btn_editar_click() {   
    modo = 1;
    let ind = this.id.substring(0, 1);
    num_edit = ind;
    //alert("click " + ind);

    let Producto = document.getElementById("[SaleDetails][" + ind + "].ProductId");
    let Cantidad = document.getElementById("[SaleDetails][" + ind + "].Quantity");
    let Precio = document.getElementById("[SaleDetails][" + ind + "].UnitPrice");


    $("#cboProducto").val(Producto.value);
    $("#txtCantidad").val(Cantidad.value);
    $("#txtPrecio").val(Precio.value);

    $("#lanzar").click();
}

function btn_delete_click() {
    let ind = this.id.substring(0, 1);
    let conf = confirm("¿Desea eliminar esta fila?");

    if (conf) {
        $("#" + ind + "_fila").remove();
        $("#" + ind + "_detalle_hi").remove();
    }
}

function order_detalle() {
    let divsHi = $(".div_detalle_hi");
    let array = [];
    for (i = 0; i < divsHi.length; i++) {
        array.push(divsHi[i].id.substring(0, 1));
    }
    array.sort();
    for (i = 0; i < array.length; i++) {
        //alert(i + "-" + array[i]);
        $("#" + array[i] + "_detalle_hi").id = i + "_detalle_hi";
        $("#" + array[i] + "_fila").id = i + "_fila"

        $("#" + array[i] + "_ProductId").name = i + "_ProductId";
        $("#" + array[i] + "_ProductId").id = i + "_ProductId";

        $("#" + array[i] + "_Quantity").name = i + "_Quantity";
        $("#" + array[i] + "_Quantity").id = i + "_Quantity";

        $("#" + array[i] + "_UnitPrice").name = i + "_UnitPrice";
        $("#" + array[i] + "_UnitPrice").id = i + "_UnitPrice";

        $("#" + array[i] + "_btnEdit").id = i + "_btnEdit";
        $("#" + array[i] + "_btnDelete").id = i + "_btnDelete";


        $("#[SaleDetails][" + array[i] + "].ProductId").name = "[SaleDetails][" + i + "].ProductId";
        $("#[SaleDetails][" + array[i] + "].ProductId").id = "[SaleDetails][" + i + "].ProductId";

        $("#[SaleDetails][" + array[i] + "].Quantity").name = "[SaleDetails][" + i + "].Quantity";
        $("#[SaleDetails][" + array[i] + "].Quantity").id = "[SaleDetails][" + i + "].Quantity";

        $("#[SaleDetails][" + array[i] + "].UnitPrice").name = "[SaleDetails][" + i + "].UnitPrice";
        $("#[SaleDetails][" + array[i] + "].UnitPrice").id = "[SaleDetails][" + i + "].UnitPrice";

    }

}

function Agregar() {

    let cboProducto = $("#cboProducto")[0];
    let cboProductoSel = cboProducto.options[cboProducto.selectedIndex].text;

    let txtCantidad = $("#txtCantidad");
    let txtPrecio = $("#txtPrecio");

    if (modo == 1)//editar
    {
        $("#" + num_edit + "_ProductId").val(cboProductoSel);
        $("#" + num_edit + "_Quantity").val($("#txtCantidad").val());
        $("#" + num_edit + "_UnitPrice").val($("#txtPrecio").val());

        document.getElementById("[SaleDetails][" + num_edit + "].ProductId").value = $("#cboProducto").val();
        document.getElementById("[SaleDetails][" + num_edit + "].Quantity").value = $("#txtCantidad").val();
        document.getElementById("[SaleDetails][" + num_edit + "].UnitPrice").value = $("#txtPrecio").val();


        document.getElementById(num_edit + "_ProductId").innerHTML= $("#cboProducto").val();
        document.getElementById(num_edit + "_Quantity").innerHTML = $("#txtCantidad").val();
        document.getElementById(num_edit + "_UnitPrice").innerHTML = $("#txtPrecio").val();

        $("#cboProducto").val("-1");
        $("#txtCantidad").val("");
        $("#txtPrecio").val("");

        modo = 0;

    }
    else//nuevo
    {
        let table = $("#tabla_detalle");
        let tr = $("<tr></tr>");
        tr.attr("id", num + "_fila");

        let td_prod = $("<td></td>");
        let td_cant = $("<td></td>");
        let td_prec = $("<td></td>");
        let td_editar = $("<td></td>");
        let td_delete = $("<td></td>");

        td_prod.html(cboProductoSel);
        td_prod.attr("id", num + "_ProductId");

        td_cant.html(txtCantidad.val());
        td_cant.attr("id", num + "_Quantity");

        td_prec.html(txtPrecio.val());
        td_prec.attr("id", num + "_UnitPrice");

        let btnEdit = $("<button></button>");
        btnEdit.attr("id", num + "_btnEdit");
        btnEdit.attr("type", "button");
        btnEdit.html("Editar");
        btnEdit.click(btn_editar_click);
        td_editar.append(btnEdit);

        let btnDelete = $("<button></button>");
        btnDelete.attr("id", num + "_btnDelete");
        btnDelete.attr("type", "button");
        btnDelete.html("Borrar");
        btnDelete.click(btn_delete_click);
        td_editar.append(btnDelete);

        tr.append(td_prod);
        tr.append(td_cant);
        tr.append(td_prec);
        tr.append(td_editar);
        tr.append(td_delete);
        table.append(tr);

        let div_detalle_hi = $("<div></div>");
        div_detalle_hi.attr("id", num + "_detalle_hi");
        div_detalle_hi.attr("className", "div_detalle_hi");

        let in_prod = $("<input>");
        let in_cant = $("<input></input>");
        let in_prec = $("<input></input>");

        in_prod.attr("type", "hidden");
        in_prod.attr("id", "[SaleDetails][" + num + "].ProductId");
        in_prod.attr("name", "[SaleDetails][" + num + "].ProductId");
        in_prod.attr("value", $("#cboProducto").val());

        in_cant.attr("type", "hidden");
        in_cant.attr("id", "[SaleDetails][" + num + "].Quantity");
        in_cant.attr("name", "[SaleDetails][" + num + "].Quantity");
        in_cant.attr("value", $("#txtCantidad").val());

        in_prec.attr("type", "hidden");
        in_prec.attr("id", "[SaleDetails][" + num + "].UnitPrice");
        in_prec.attr("name", "[SaleDetails][" + num + "].UnitPrice");
        in_prec.attr("value", $("#txtPrecio").val());

        let div_detalle = $("#div_detalle");
        div_detalle_hi.append(in_prod);
        div_detalle_hi.append(in_cant);
        div_detalle_hi.append(in_prec);
        div_detalle.append(div_detalle_hi);

        $("#cboProducto").val("-1");
        $("#txtCantidad").val("");
        $("#txtPrecio").val("");

        num = num + 1;
        modo = 0;
    }
}
