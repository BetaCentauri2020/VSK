;(function ($) {


//growth-summary


    if ($('#growth-summary').length) {
        var options = {
            series: [{
                name: "Desktops",
                data: [10, 41, 35, 51, 49, 62, 69]
            }],
            chart: {
                height: 300,
                type: 'line',
                zoom: {
                    enabled: false
                },
                toolbar:false
            },
            dataLabels: {
                enabled: false
            },
            stroke: {
                curve: 'straight'
            },
            title: {
                text: undefined,
                align: 'left'
            },
            grid: {
                borderColor: '#eff2f5',
                column: {
                    colors: ['#e5fae8', '#fee6ef','#fbfce7','#fff2e5','#e5f8fc','#f1e5f8'],
                },
                xaxis: {
                    lines: {
                        show: true
                    }
                }
            },
            xaxis: {
                categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
            }
        };

        var chart = new ApexCharts(document.querySelector("#growth-summary"), options);
        chart.render();
    }


    if ($('#sales-analytics').length) {
        /* chart for home two */
        var options = {
            series: [{
                name: '',
                type: 'area',
                data: [44, 55, 31, 47, 31, 43, 26, 41, 31, 47, 33]
            }, {
                name: '',
                type: 'line',
                data: [55, 69, 45, 61, 43, 54, 37, 52, 44, 61, 43]
            }],
            legend: {
                show: false,
            },
            chart: {
                height: 300,
                type: 'line',
                toolbar: {
                    show: false,
                },
            },
            stroke: {
                curve: 'smooth',
                colors: ['#ff7e00', '#fb1ffe'],
                dashArray: [5],
            },
            fill: {
                type: 'solid',
                opacity: [0.35, 1],
                colors: ['#ff7e00']
            },
            labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            markers: {
                size: 0
            },
            yaxis: [
                {
                    title: {
                        text: '',
                    },
                },
            ],
            tooltip: {
                shared: false,
                intersect: false,
                y: {
                    formatter: function (y) {
                        if (typeof y !== "undefined") {
                            return y.toFixed(0) + " points";
                        }
                        return y;
                    }
                }
            },

        };

        var chart = new ApexCharts(document.querySelector("#sales-analytics"), options);
        chart.render();
    }


    /* most sale chart */

    if ($('#most-sale-chart').length) {
        am4core.ready(function () {

// Themes begin
            am4core.useTheme(am4themes_animated);
// Themes end

// Create chart instance
            var chart = am4core.create("most-sale-chart", am4charts.PieChart);

// Add and configure Series
            var pieSeries = chart.series.push(new am4charts.PieSeries());
            pieSeries.dataFields.value = "litres";
            pieSeries.dataFields.category = "country";

// Let's cut a hole in our Pie chart the size of 30% the radius
            chart.innerRadius = am4core.percent(30);

            pieSeries.slices.template.stroke = am4core.color("#fff");
            pieSeries.slices.template.strokeWidth = 2;
            pieSeries.slices.template.strokeOpacity = 1;
            pieSeries.slices.template
                .cursorOverStyle = [
                {
                    "property": "cursor",
                    "value": "pointer"
                }
            ];

            pieSeries.alignLabels = false;
            pieSeries.labels.template.bent = true;
            pieSeries.labels.template.radius = 3;
            pieSeries.labels.template.padding(0, 0, 0, 0);
            pieSeries.ticks.template.disabled = true;
            pieSeries.colors.list = [
                am4core.color("#fb00d5"),
                am4core.color("#d91023"),
                am4core.color("#f7b412"),
                am4core.color("#430df3"),
            ];
            var shadow = pieSeries.slices.template.filters.push(new am4core.DropShadowFilter);
            shadow.opacity = 0;
            var hoverState = pieSeries.slices.template.states.getKey("hover");
            var hoverShadow = hoverState.filters.push(new am4core.DropShadowFilter);
            hoverShadow.opacity = 0.7;
            hoverShadow.blur = 5;


// Add a legend
            chart.legend = new am4charts.Legend();

            chart.data = [{
                "country": "Very Satisfied",
                "litres": 108.8,
            }, {
                "country": "Not Satisfied",
                "litres": 165.8
            }, {
                "country": "Satisfied ",
                "litres": 139.9
            }, {
                "country": "Satisfied",
                "litres": 128.3
            }];

        });
    }


    /*  home page two map */

    if ($('#worldwide-customer').length) {

// Set themes
        am4core.useTheme(am4themes_animated);

// Create the map chart
        var chart = am4core.create("worldwide-customer", am4maps.MapChart);

// Check if proper geodata is loaded
        try {
            chart.geodata = am4geodata_worldLow;
        } catch (e) {
            chart.raiseCriticalError({
                "message": "Map geodata could not be loaded. Please download the latest <a href=\"https://www.amcharts.com/download/download-v4/\">amcharts geodata</a> and extract its contents into the same directory as your amCharts files."
            });
        }

// Set projection to be used
// @see {@link https://www.amcharts.com/docs/v4/reference/mapchart/#projection_property}
        chart.projection = new am4maps.projections.Miller();

// Create polygon series
        var polygonSeries = chart.series.push(new am4maps.MapPolygonSeries());
        polygonSeries.useGeodata = true;
        polygonSeries.exclude = ["AQ"]; // Exclude Antractica
        polygonSeries.tooltip.fill = am4core.color("#000000");

        var colorSet = new am4core.ColorSet();

// Configure polygons
        var polygonTemplate = polygonSeries.mapPolygons.template;
        polygonTemplate.tooltipText = "{name}";
        polygonTemplate.togglable = true;

// Set events to apply "active" state to clicked polygons
        var currentActive;
        polygonTemplate.events.on("hit", function (event) {
            // if we have some country selected, set default state to it
            if (currentActive) {
                currentActive.setState("default");
            }
            chart.maxZoomLevel = 32;
            chart.zoomToMapObject(event.target);
            currentActive = event.target;
            chart.maxZoomLevel = 1;
        });

// Configure states
// @see {@link https://www.amcharts.com/docs/v4/concepts/states/}

// Configure "hover" state
        var hoverState = polygonTemplate.states.create("hover");
        hoverState.properties.fill = colorSet.getIndex(0);

// Configure "active" state
        var activeState = polygonTemplate.states.create("active");
        activeState.properties.fill = colorSet.getIndex(4);

// Disable zoom and pan
        chart.maxZoomLevel = 1;
        chart.seriesContainer.draggable = false;
        chart.seriesContainer.resizable = false;
    }


    if ($('#earnings').length) {
        var options = {
            series: [{
                name: 'series1',
                data: [31, 40, 28, 51, 42, 109, 100]
            }],
            legend: {
                show: false,
            },
            chart: {
                height: 350,
                type: 'area',
                toolbar: {
                    show: false,
                },
            },
            dataLabels: {
                enabled: false,
            },
            xaxis: {
                type: 'category',
                categories: ['Jan 1', 'Feb 1', 'Mar 1', 'Apr 1', 'May 1', 'May 1', 'Jun 1', 'Jul 1', 'Aug 1', 'Sep 1'],
            },
            stroke: {
                curve: 'smooth',
                colors: ['#fe840e'],
            },
            fill: {
                colors: ['#f7cfaa'],
            },
            tooltip: {
                shared: false,
                intersect: false,
                x: {
                    format: 'dd/MM/yy HH:mm'
                },
            },
        };

        var chart = new ApexCharts(document.querySelector("#earnings"), options);
        chart.render();
    }


    if ($('#chartdiv1').length) {
        am4core.ready(function () {

// Themes begin
            am4core.useTheme(am4themes_animated);
// Themes end

// Create chart
            var chart = am4core.create("chartdiv1", am4charts.PieChart);
            chart.hiddenState.properties.opacity = 0;

            chart.data = [
                {
                    country: "Books",
                    value: 260
                },
                {
                    country: "Fuel",
                    value: 230
                },
                {
                    country: "Salary",
                    value: 200
                },
                {
                    country: "Medical",
                    value: 165
                },
                {
                    country: "Maintenance",
                    value: 139
                },
                {
                    country: "Food",
                    value: 128
                }
            ];

            var series = chart.series.push(new am4charts.PieSeries());
            series.dataFields.value = "value";
            series.dataFields.radiusValue = "value";
            series.dataFields.category = "country";
            series.slices.template.cornerRadius = 6;
            series.colors.step = 3;
            series.hiddenState.properties.endAngle = -90;
            series.ticks.template.disabled = true;
            series.alignLabels = false;

        });
    }


    if ($('#chartdiv2').length) {
        am4core.ready(function () {

// Themes begin
            am4core.useTheme(am4themes_animated);
// Themes end

// Create chart instance
            var chart = am4core.create("chartdiv2", am4charts.PieChart);

// Add and configure Series
            var pieSeries = chart.series.push(new am4charts.PieSeries());
            pieSeries.dataFields.value = "litres";
            pieSeries.dataFields.category = "country";

// Let's cut a hole in our Pie chart the size of 30% the radius
            chart.innerRadius = am4core.percent(30);

// Put a thick white border around each Slice
            pieSeries.slices.template.stroke = am4core.color("#fff");
            pieSeries.slices.template.strokeWidth = 2;
            pieSeries.slices.template.strokeOpacity = 1;
            pieSeries.slices.template
                // change the cursor on hover to make it apparent the object can be interacted with
                .cursorOverStyle = [
                {
                    "property": "cursor",
                    "value": "pointer"
                }
            ];

            pieSeries.alignLabels = false;
            pieSeries.labels.template.bent = true;
            pieSeries.labels.template.radius = 3;
            pieSeries.labels.template.padding(0, 0, 0, 0);

            pieSeries.ticks.template.disabled = true;

// Create a base filter effect (as if it's not there) for the hover to return to
            var shadow = pieSeries.slices.template.filters.push(new am4core.DropShadowFilter);
            shadow.opacity = 0;

// Create hover state
            var hoverState = pieSeries.slices.template.states.getKey("hover"); // normally we have to create the hover state, in this case it already exists

// Slightly shift the shadow and make it more prominent on hover
            var hoverShadow = hoverState.filters.push(new am4core.DropShadowFilter);
            hoverShadow.opacity = 0.7;
            hoverShadow.blur = 5;

            chart.data = [{
                "country": "Lithuania",
                "litres": 501.9
            }, {
                "country": "Germany",
                "litres": 165.8
            }, {
                "country": "Australia",
                "litres": 139.9
            }];

        });
    }


})(jQuery)