/*THIS DOM NEEDED FOR FIX BUG*/

$(document).ready(function () {
    const dataTable = $('#articlesTable').DataTable({
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
                    let url = window.location.href;                /* GET CURRENT URL*/
                    url = url.replace("/Index", "");
                    window.open(`${url}/Add`, "self");                      /*GO TO URL*/
                }
            },
            {
                text: 'Refresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Article/GetAllArticles/',
                        dataType: 'json',
                        beforeSend: function () {
                            $('#articlesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const articleResult = jQuery.parseJSON(data);             /* deserialize data*/
                            dataTable.clear();
                            console.log(articleResult);
                            if (articleResult.Data.Status === 0) {
                                let categoriesArray = [];                            /*for jsonnet problem*/
                                $.each(articleResult.Data.Articles.$values, function (index, article) {             /*$.each*/
                                    const newArticle = getJsonNetObject(article, articleResult.Data.Articles.$values);              /*get as object when objects comes with only ref property  */
                                    let newCategory = getJsonNetObject(newArticle.Category, newArticle);
                                    if (newCategory !== null) {
                                        categoriesArray.push(newCategory);
                                    }
                                    if (newCategory === null) {
                                        newCategory = categoriesArray.find((category) => {
                                            return category.$id === newArticle.Category.$ref;                   /*get category with the id of newArticle.Category.$ref*/
                                        });
                                    }
                                    console.log(newArticle);
                                    console.log(newCategory);
                                    const newTableRow = dataTable.row.add([
                                        newArticle.Id,
                                        newCategory.Name,
                                        newArticle.Title,
                                        `<img src="/img/${newArticle.Thumbnail}" alt="${newArticle.Title}" class="my-image-table" />`,
                                        `${convertToShortDate(newArticle.Date)}`,
                                        newArticle.ViewCount,
                                        newArticle.CommentCount,
                                        `${newArticle.IsActive ? "Yes" : "No"}`,
                                        `${newArticle.IsDeleted ? "Yes" : "No"}`,
                                        `${convertToShortDate(newArticle.CreatedDate)}`,
                                        newArticle.CreatedByName,
                                        `${convertToShortDate(newArticle.ModifiedDate)}`,
                                        newArticle.ModifiedByName,
                                                `
                                        <button class="btn btn-primary btn-sm btn-update" data-id="${newArticle.Id}"><span class="fas fa-edit"></span></button>
                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${newArticle.Id}"><span class="fas fa-minus-circle"></span></button>
                                                `
                                    ]).node();
                                    const jqueryTableRow = $(newTableRow);
                                    jqueryTableRow.attr('name', `${newArticle.Id}`);
                                });
                                dataTable.draw();                   /*apply,show changes*/
                                $('.spinner-border').hide();
                                $('#articlesTable').fadeIn(1400);
                            } else {

                                toastr.error(`${articleResult.Data.Message}`, 'Error')
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#articlesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Error')        /*get error response text, 404 not found*/
                        }
                    })
                }
            }

        ]
    });

    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');             /*select this element*/
        const tableRow = $(`[name="${id}"]`);
        const articleTitle = tableRow.find('td:eq(2)').text();      /*select td via index*/
        Swal.fire({
            title: 'Are you sure?',
            text: `${articleTitle} will be deleted!`,
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
                    data: { articleId: id },
                    url: '/Admin/Article/Delete/',
                    success: function (data) {
                        const articleResult = jQuery.parseJSON(data);
                        if (articleResult.Status === 0) {
                            Swal.fire(
                                'Deleted!',
                                `${articleResult.Message}`,
                                'success'
                            );
                            dataTable.row(tableRow).remove().draw();
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Unsuccessfull operation!',
                                text: `${articleResult.Message}`
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


});