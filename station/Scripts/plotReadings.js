function plotReadings(equipmentID, stationID,sensorModel, measureType, startDate, endDate) {

    //var baseUrl = "http://localhost:60480/api/stations/";
    var baseUrl = "http://airqualitystation.azurewebsites.net/api/stations/";
    var dataUrl = baseUrl + stationID +"/sensors/"+equipmentID+ "/datapoints/" + startDate + "/" + endDate;
    
    //Set title for the chart
    var plotTitle = measureType + " readings from " + sensorModel;
    //Set id for div that will contain a chart
    var readingDivId = "readingDiv" + equipmentID;
    //Create a div for a chart within readingPlots div
    var readingDivs = d3.select("#readingsPlots").append("div")
            .attr("id", readingDivId);

    var margin = {
        top: 20,
        right: 50,
        bottom: 30,
        left: 50
    },
          width = 800 - margin.left - margin.right,
          height = 200 - margin.top - margin.bottom;

    readingDivs.append("p")
            .text(plotTitle)
            .attr("class", "title");

    //D3.json uses asynchronous calls. 
    //The data must be loaded before the rest
    //of the script is executed. Thats why the 
    //code creating graph is enclosed in a function
    // and used as a callback after the data is loaded.
    
    var dataset;

    //use this in prod
    d3.json(dataUrl, function (data) {
        dataset = data;
        //If there is data then build graph
        if (dataset.length > 0) {
            buildGraph();
        } else { noDataAvailable(); } //display information if data set is empty
    });

    //custom message if there is no data
    function noDataAvailable() {
        readingDivs.append("p")
            .text("No data available")
            .attr("class", "container");
    }


    // Build chart
    function buildGraph() {

        var xScale = d3.time.scale()
          .domain([new moment(dataset[0].TimeStamp), new moment(dataset[dataset.length - 1].TimeStamp)])
          .range([0, width]);

        var yScale = d3.scale.linear()
          .domain([0, d3.max(dataset, function (d) {
              return d.Value;
          })])
          .range([height, 0]);


        var xAxis = d3.svg.axis()
          .scale(xScale)
          .orient('bottom')
          .ticks(d3.time.hours, 1)
          .tickFormat(d3.time.format('%H:%M'))
          .tickSize(6)
          .tickPadding(8);

        var yAxis = d3.svg.axis()
          .scale(yScale)
          .orient("left")
          .ticks(5);

        var line = d3.svg.line()
          .x(function (d) {
              return xScale(new moment(d.TimeStamp));
          })
          .y(function (d) {
              return yScale(d.Value);
          });

        var svg = d3.select("#" + readingDivId).append("svg")
          .attr("width", width + margin.left + margin.right)
          .attr("height", height + margin.top + margin.bottom)
          .append("g")
          .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

        svg.append("g")
          .attr("class", "x axis")
          .attr("transform", "translate(0," + height + ")")
          .call(xAxis);

        svg.append("g")
          .attr("class", "axis")
          .attr("transform", "translate(-5,0)")
          .call(yAxis);

        svg.append("path")
          .data([dataset])
          .attr("class", "line")
          .attr("d", line);

        svg.selectAll("circle")
          .data(dataset)
          .enter()
          .append("circle")
          .attr("class", "marker")
          .attr("cx", function (d) {
              return xScale(new moment(d.TimeStamp));
          })
          .attr("cy", function (d) {
              return yScale(d.Value);
          })
          .attr("r", 5)
          .on("mouseover", function (d) {
              d3.select("#tooltip")
                .style("top", (event.pageY + 15) + "px")
                .style("left", (event.pageX + 15) + "px")
                .select("#value")
                .text(d.Value);
              d3.select("#tooltip")
                  .select("#date")
                .text(d.TimeStamp);
              d3.select("#tooltip").classed("hidden", false);
          })

        .on("mouseout", function () {
            d3.select("#tooltip").classed("hidden", true);
        });
    }
}