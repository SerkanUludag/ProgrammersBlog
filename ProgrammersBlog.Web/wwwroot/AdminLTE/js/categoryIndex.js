/*THIS DOM NEEDED FOR FIX BUG*/

$(document).ready(function () {
    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[6, "desc"]],                            
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
                        url: '/Admin/Category/GetAllCategories/',
                        dataType: 'json',
                        beforeSend: function () {
                            $('#categoriesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const categoryListDto = jQuery.parseJSON(data);             /* deserialize data*/
                            console.log(categoryListDto);
                            if (categoryListDto.Status === 0) {
                                let tableBody = "";
                                $.each(categoryListDto.Categories.$values, function (index, category) {             /*$.each*/
                                    tableBody += `
                                                    <tr name=${category.Id}>
                                                        <td>${category.Id}</td>
                                                        <td>${category.Name}</td>
                                                        <td>${category.Description}</td>
                                                        <td>${convertFirstLetterToUpperCase(category.IsActive.toString())}</td>
                                                        <td>${convertFirstLetterToUpperCase(category.IsDeleted.toString())}</td>
                                                        <td>${category.Note}</td>
                                                        <td>${convertToShortDate(category.CreatedDate)}</td>
                                                        <td>${category.CreatedByName}</td>
                                                        <td>${convertToShortDate(category.ModifiedDate)}</td>
                                                        <td>${category.ModifiedByName}</td>
                                                        <td>
                                                            <button class="btn btn-primary btn-sm btn-update" data-id="${category.Id}"><span class="fas fa-edit"></span></button>
                                                            <button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span></button>
                                                        </td>
                                                    </tr>`
                                });
                                $('#categoriesTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#categoriesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${categoryListDto.Message}`, 'Error')
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#categoriesTable').fadeIn(1000);
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
        const url = '/Admin/Category/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {          /* $.load alternative*/
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        placeHolderDiv.on('click',                  /* not to refresh page we do this way (not submit button)*/
            '#btnSave',
            function (event) {
                event.preventDefault();         /* to make sure preventing any other button events like submit(refresh)*/
                const form = $('#form-category-add');
                const actionUrl = form.attr('action');      /* get form action url*/
                const dataToSend = form.serialize();        /* convert form to categaryAddDto*/
                $.post(actionUrl, dataToSend).done(function (data) {
                    const categoryAddAjaxModel = jQuery.parseJSON(data);
                    const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);          // search for .model-body restricted inside categoryAddAjaxModel.CategoryAddPartial
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === "True";          /* return true or false*/
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');                                     /* C# DateTime ==> string in JS if not new Date()*/
                        const newTableRow = `
                                            <tr name="${categoryAddAjaxModel.CategoryDto.Category.Id}">
                                                <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                                                <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                                                <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                                                <td>${convertFirstLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsActive.toString())}</td>
                                                <td>${convertFirstLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsDeleted.toString())}</td>
                                                <td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
                                                <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                                <td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
                                                <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                                <td>${categoryAddAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                                                <td>
                                                    <button class="btn btn-primary btn-sm btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button>
                                                </td>
                                            </tr>
                                        `;

                        const newTableRowObject = $(newTableRow);                /* convert string to jquery/javascript object*/
                        newTableRowObject.hide();
                        $('#categoriesTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);                         /* fade in*/
                        toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Success!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {                    /* '>' inside */
                            let text = $(this).text();                                               /*this li*/
                            summaryText += `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });
    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');             /*select this element*/
        const tableRow = $(`[name="${id}"]`);
        const categoryName = tableRow.find('td:eq(1)').text();      /*select tr via index*/
        Swal.fire({
            title: 'Are you sure?',
            text: `${categoryName} will be deleted!`,
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
                    data: { categoryId: id },
                    url: '/Admin/Category/Delete/',
                    success: function (data) {
                        const categoryDto = jQuery.parseJSON(data);
                        if (categoryDto.Status === 0) {
                            Swal.fire(
                                'Deleted!',
                                `${categoryDto.Category.Name} has been deleted.`,
                                'success'
                            );
                            tableRow.fadeOut(3500);
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Unsuccessfull operation!',
                                text: `${categoryDto.Message}`
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
        const url = '/Admin/Category/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { categoryId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Error occurred");
                });
            });


        /* Ajax POST*/
        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();
            const form = $('#form-category-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {

                const categoryUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(categoryUpdateAjaxModel);
                const newFormBody = $('.modal-body', categoryUpdateAjaxModel.CategoryUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                                            <tr name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}">
                                                <td>${categoryUpdateAjaxModel.CategoryDto.Category.Id}</td>
                                                <td>${categoryUpdateAjaxModel.CategoryDto.Category.Name}</td>
                                                <td>${categoryUpdateAjaxModel.CategoryDto.Category.Description}</td>
                                                <td>${convertFirstLetterToUpperCase(categoryUpdateAjaxModel.CategoryDto.Category.IsActive.toString())}</td>
                                                <td>${convertFirstLetterToUpperCase(categoryUpdateAjaxModel.CategoryDto.Category.IsDeleted.toString())}</td>
                                                <td>${categoryUpdateAjaxModel.CategoryDto.Category.Note}</td>
                                                <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                                <td>${categoryUpdateAjaxModel.CategoryDto.Category.CreatedByName}</td>
                                                <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                                <td>${categoryUpdateAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                                                <td>
                                                    <button class="btn btn-primary btn-sm btn-update" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit"></span></button>
                                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button>
                                                </td>
                                            </tr>
                                        `;
                    const newTableRowObject = $(newTableRow);
                    const categoryTableRow = $(`[name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"]`);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Message}`, "Success");
                } else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {                    /* '>' inside */
                        let text = $(this).text();                                               /*this li*/
                        summaryText += `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function (response) {
                console.log(response);

            });

        });


    });
});