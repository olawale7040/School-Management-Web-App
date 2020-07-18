var dataTable;

$(function () {
    handleDataTable()
}
)
function handleDataTable() {
    dataTable = $("#dataLoad").DataTable({
        "ajax": {
            url: "/api/department",
            type: "Get",
            dataType: "json"
        },
        "columns": [
            { data: "name", width: "30%" },
            { data: "faculty.name", width: "30%" },
            {
                data: "id",
                render: function (data) {
                    return `
                        <div>
                              <a href="/Admin/departments/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer;">
                                <i class="fas fa-edit"></i> Edit
                                </a>
                                <a onclick=Delete('/api/department/'+${data}) class="btn btn-danger text-white" style="cursor:pointer;">
                                <i class="fas fa-trash-alt"></i> Delete
                                </a>
                         </div>
`
                },
                width: "40%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        }
    })
};

function Delete(url) {
    swal({
        title: "You are sure you want to delete",
        text: "You won't be able to restore the date",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then(response => {
        if (response) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.status) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}