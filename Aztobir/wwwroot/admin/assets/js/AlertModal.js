$(function (e) {
    $(document).on("click", ".delete-btn", function (e) {
        e.preventDefault();
        
        let url = $(this).attr("href");
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(url).then(data => {
                    //if (data.ok) {
                    //        window.location.reload(true);
                    //}
                    

                        if (data.ok) {
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success')
                        }
                        else {
                            alert("warning");
                        }

                
                    setTimeout(function () { window.location.reload(true);  }, 900);
                    //
                })

            }
        })
    })
})