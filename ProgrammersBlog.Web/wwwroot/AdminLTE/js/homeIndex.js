$(document).ready(function () {
    // datatable
    $('#articlesTable').dataTable({
        "order": [[4, "desc"]]              /*order*/
    });

    // Chart.js

    $.get('/Admin/Article/GetAllByViewCount/?isAscending=false&takeSize=10', function (data) {
        const articleResult = jQuery.parseJSON(data);

        let viewCountContext = $('#viewCountChart');        // select canvas

        let viewCountChart = new Chart(viewCountContext,
            {
                type: 'bar',
                data: {
                    labels: articleResult.$values.map(article => article.Title),          // mapping,    $values(referencehandler) will be solved at .net6
                    datasets: [
                        {
                            label: 'View Count',
                            data: articleResult.$values.map(article => article.ViewCount),
                            backgroundColor: '#fb3640'/*['#fb3640', '#ffc75f', '#f9f871', '#ff5e78', '#a4ebf3']*/,
                            hoverBorderWidth: 4,
                            hoverBorderColor: 'black'
                        },
                        {
                            label: 'Comment Count',
                            data: articleResult.$values.map(article => article.CommentCount),
                            backgroundColor: '#fdca40'/*['#fdca40', '#ffc75f', '#f9f871', '#ff5e78', '#a4ebf3']*/,
                            hoverBorderWidth: 4,
                            hoverBorderColor: 'black'
                        }
                    ]
                },
                options: {
                    plugins: {
                        legend: {
                            labels: {
                                font: {
                                    size: 18
                                }
                            }
                        }
                    }
                }
            });
    });
});