window.showSweetAlert = (type, title, message, dotnetHelper, id) => {
    if (dotnetHelper != null) {
        console.log("ok");
        Swal.fire({
            title: title,
            text: message,
            icon: type,
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, nonactive it!"
        }).then((result) => {
            if (result.isConfirmed) {
                dotnetHelper.invokeMethodAsync("DeleteData", id);
            }
        });
    } else {
        console.log("no");
        Swal.fire({
            icon: type,     // 'success', 'error', 'warning', 'info'
            title: title,
            text: message,
            confirmButtonText: 'OK'
        });
    }
};
//window.showSweetAlert = (type, title, message, dotNetRef) => {
//    Swal.fire({
//        icon: type,     // 'success', 'error', 'warning', 'info'
//        title: title,
//        text: message,
//        confirmButtonText: 'OK'
//    });
//};
