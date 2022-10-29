async function listaProveedores() {
    var response = await supplierGetAll();
    for (const key in response) {
        var newRowContent =
            '<tr><td scope="row">' +
            response[key].id +
            "</td><td>" +
            response[key].identification +
            "</td><td>" +
            response[key].name +
            '</td><td class="text-center"><a class="text-warning" onclick="cargaEditarProveedor('+response[key].id +
            ')" data-bs-toggle="modal" data-bs-target="#modalEditar"><i class="fa-regular fa-pen-to-square"></i></a></td><td class="text-center"><a class="text-danger" onclick="eliminarProveedor('+response[key].id +
            ')"><i class="fa-regular fa-trash"></i></a></td></tr>';
        $("#proveedorTableBody").append(newRowContent);
    }
}