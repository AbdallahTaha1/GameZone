$(document).ready(function () {
    $(".js-delete").on("click", function () {
        var btn = $(this);
        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });

        swal.fire({
            title: "Are you sure that you need to delete this game?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            console.log(result);
            console.log(`Games/Delete/${btn.data('id')}`)
            if (result.isConfirmed) {
                $.ajax({
                    url: `Games/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            "Deleted!",
                            "Your file has been deleted.",
                            "success"
                        );
                        btn.parents('tr').fadeOut('slow', function () {
                            // Optional: Remove the element from the DOM after fading out
                            $(this).remove();
                        });
                    },
                    error: function () {
                        swal.fire(
                            "Oooops...",
                            "Something went wrong.",
                            "error"
                        );
                    }
                });
            }
        });     
    });
});