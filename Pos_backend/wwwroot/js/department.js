var dataTable;

$(document).ready(function () {
    loadDataTable();
    console.log("this is department page")
});

function loadDataTable() {
    dataTable = $('#tblDeptData').DataTable({
        "ajax": { url: '/admin/department/getall' },
        "columns": [
            { data: 'deptCode' },
            { data: 'nameEN' },
            { data: 'nameKO' },
            {
                data: 'id',
                render: function (data) {
                    return `<div role="group">
                    <a href="/admin/department/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit </a>
                    <a onClick=Delete('/admin/department/delete/${data}') class="btn btn-danger"> <i class="bi bi-trash-fill"></i> Delete </a>
                    </div >`
                }
            }
        ],
        "responsive": true
    });
}