var dataTable;

$(function () {
    handleDataTable()
}
)
function handleDataTable() {
    dataTable = $("#dataLoad").DataTable({
        "ajax": {
            url: "/api/student",
            type: "Get",
            dataType: "json"
        },
        "columns": [
            { data: "firstName", width: "15%" },
            { data: "matricNo", width: "15%" },
            { data: "department.name", width: "20%" },
            { data: "level", width: "20%" },
            {
                data: "id",
                render: function (data) {
                    return `
                        <div>
                                <a onclick=Delete('/api/student/'+${data}) class="btn btn-danger text-white" style="cursor:pointer;">
                                <i class="fas fa-trash-alt"></i> Delete
                                </a>
                         </div>
`
                },
                width: "30%"
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