$(document).ready(function () {
    console.log("this is category page")

    loadCategoryDataTable();
});

function loadCategoryDataTable() {
    dataTable = $('#tblCatData').DataTable({
        "ajax": { url: '/admin/category/getall' },
        "columns": [
            { data: "id" },
            { data: 'deptCode' },
            { data: 'categoryCode' },
            { data: 'nameEN' },
            { data: 'nameKO' },
            {
                data: 'id',
                render: function (data) {
                    console.log('data: ', data)
                    return `<div role="group">
                    <a href="/admin/category/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit </a>
                    <a onClick=Delete('/admin/category/delete/${data}') class="btn btn-danger"> <i class="bi bi-trash-fill"></i> Delete </a>
                    </div >`
                }
            }
        ],
        "responsive": true
    });
}