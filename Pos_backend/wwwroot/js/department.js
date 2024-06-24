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
                    console.log('data: ',data)
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
function Delete(url) {
    
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}