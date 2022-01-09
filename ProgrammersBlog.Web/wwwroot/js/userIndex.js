/*THIS DOM NEEDED FOR FIX BUG*/

$(document).ready(function () {
     const dataTable = $('#usersTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Add',
                attr: {
                    id: "btnAdd"
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            },
            {
                text: 'Refresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/User/GetAllUsers/',
                        dataType: 'json',
                        beforeSend: function () {
                            $('#usersTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const userListDto = jQuery.parseJSON(data);             /* deserialize data*/
                            dataTable.clear();
                            console.log(userListDto);
                            if (userListDto.Status === 0) {
                                $.each(userListDto.Users.$values, function (index, user) {             /*$.each*/
                                    const newTableRow = dataTable.row.add([                                                             /*datatable API*/
                                        user.Id,
                                        user.UserName,
                                        user.Email,
                                        user.PhoneNumber,
                                        `<img src="/img/${user.Picture}" alt="${user.UserName}" class="my-image-table" />`,

                                        `
                                            <button class="btn btn-primary btn-sm btn-update" data-id="${user.Id}"><span class="fas fa-edit"></span></button>
                                            <button class="btn btn-danger btn-sm btn-delete" data-id="${user.Id}"><span class="fas fa-minus-circle"></span></button>
                                        `
                                    ]).node();                      /*node => select*/
                                    const jqueryTableRow = $(newTableRow);
                                    jqueryTableRow.attr('name', `${user.Id}`);
                                });
                                dataTable.draw();                   /*apply,show changes*/
                                $('.spinner-border').hide();
                                $('#usersTable').fadeIn(1400);
                            } else {

                                toastr.error(`${userListDto.Message}`, 'Error')
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#usersTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Error')        /*get error response text, 404 not found*/
                        }
                    })
                }
            }

        ]
    });

    // datatable ends here
    //AJAX GET

    $(function () {
        const url = '/Admin/User/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {          /* $.load alternative*/
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        // AJAX POST

        placeHolderDiv.on('click',                  /* not to refresh page we do this way (not submit button)*/
            '#btnSave',
            function (event) {
                event.preventDefault();         /* to make sure preventing any other button events like submit(refresh)*/
                const form = $('#form-user-add');
                const actionUrl = form.attr('action');      /* get form action url*/
                const dataToSend = new FormData(form.get(0))        /*there is IFormFile so we dont use form.serialize*/
                $.ajax({
                    url: actionUrl,
                    type: "POST",
                    data: dataToSend,            /*FormData*/
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const userAddAjaxModel = jQuery.parseJSON(data);
                        const newFormBody = $('.modal-body', userAddAjaxModel.UserAddPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === "True";          /* return true or false*/
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');                                     /* C# DateTime ==> string in JS if not new Date()*/
                            const newTableRow = dataTable.row.add([                                                             /*datatable API*/
                                userAddAjaxModel.UserDto.User.Id,
                                userAddAjaxModel.UserDto.User.UserName,
                                userAddAjaxModel.UserDto.User.Email,
                                userAddAjaxModel.UserDto.User.PhoneNumber,
                                `<img src="/img/${userAddAjaxModel.UserDto.User.Picture}" alt="${userAddAjaxModel.UserDto.User.UserName}" class="my-image-table" />`,

                                `
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span></button>
                                `
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${userAddAjaxModel.UserDto.User.Id}`);
                            dataTable.row(newTableRow).draw();
                            toastr.success(`${userAddAjaxModel.UserDto.Message}`, 'Success!');
                        } else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {                    /* '>' inside */
                                let text = $(this).text();                                               /*this li*/
                                summaryText += `*${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });
            });
    });
    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');             /*select this element*/
        const tableRow = $(`[name="${id}"]`);
        const userName = tableRow.find('td:eq(1)').text();      /*select td via index*/
        Swal.fire({
            title: 'Are you sure?',
            text: `${userName} will be deleted!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { userId: id },
                    url: '/Admin/User/Delete/',
                    success: function (data) {
                        const userDto = jQuery.parseJSON(data);
                        if (userDto.Status === 0) {
                            Swal.fire(
                                'Deleted!',
                                `${userDto.User.UserName} has been deleted.`,
                                'success'
                            );
                            dataTable.row(tableRow).remove().draw();
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Unsuccessfull operation!',
                                text: `${userDto.Message}`
                            });
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        toastr.error(`${err.responseText}`, "Error!");
                    }
                });
            }
        });
    });

    $(function () {
        const url = '/Admin/User/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { userId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Error occurred");
                });
            });


        /* Ajax POST*/
        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();
            const form = $('#form-user-update');
            const actionUrl = form.attr('action');
            const dataToSend = new FormData(form.get(0))        /*there is IFormFile so we dont use form.serialize*/
            $.ajax({
                url: actionUrl,
                type: "POST",
                data: dataToSend,            /*FormData*/
                processData: false,
                contentType: false,
                success: function (data) {
                    const userUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(userUpdateAjaxModel);
                    const id = userUpdateAjaxModel.UserDto.User.Id;
                    const tableRow = $(`[name="${id}"]`);
                    const newFormBody = $('.modal-body', userUpdateAjaxModel.UserUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        dataTable.row(tableRow).data([                                                             /*datatable API*/
                            userUpdateAjaxModel.UserDto.User.Id,
                            userUpdateAjaxModel.UserDto.User.UserName,
                            userUpdateAjaxModel.UserDto.User.Email,
                            userUpdateAjaxModel.UserDto.User.PhoneNumber,
                            `<img src="/img/${userUpdateAjaxModel.UserDto.User.Picture}" alt="${userUpdateAjaxModel.UserDto.User.UserName}" class="my-image-table" />`,
                            `
                                <button class="btn btn-primary btn-sm btn-update" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span></button>
                            `
                        ]);
                        tableRow.attr("name", `${id}`);
                        dataTable.row(tableRow).invalidate();                       /*let datatable know this row is new*/
                        toastr.success(`${userUpdateAjaxModel.UserDto.Message}`, "Success");
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {                    /* '>' inside */
                            let text = $(this).text();                                               /*this li*/
                            summaryText += `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });

        });
    

    });
});