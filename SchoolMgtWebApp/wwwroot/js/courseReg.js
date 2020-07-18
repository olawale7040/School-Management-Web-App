var dataTable;

$(function () {
    handleDataTable()
}
)
function handleDataTable() {
    dataTable = $("#dataLoad").DataTable({
        "ajax": {
            url: "/api/course",
            type: "Get",
            dataType: "json"
        },
        "columns": [
            { data: "courseCode", width: "20%" },
            { data: "courseTitle", width: "20%" },
            { data: "courseUnit", width: "15%" },
            { data: "semester", width: "15%" },
            {
                data: "id",
                render: function (data) {
                    return `
                        <div>
                              <a href="/Admin/courses/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer;">
                                <i class="fas fa-edit"></i> Add
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