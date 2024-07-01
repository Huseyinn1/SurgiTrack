var optionsProfileVisit = {

    annotations: {
        position: "back",
    },
    dataLabels: {
        enabled: false,
    },
    chart: {
        type: "bar",
        height: 300,
    },
    fill: {
        opacity: 1,
    },
    plotOptions: {},
    series: [
        {
            name: "sales",
            data: [9,15,5,20,4,30,24],
        },
    ],
    colors: "#435ebe",
    xaxis: {
        categories: [
            "AnalAtz",  // AnalAtrezi k�saltmas�
            "AntiR",    // AntiReflu k�saltmas�
            "Apd",      // Apandisit k�saltmas�
            "DH",       // DiyafragmaHernisi k�saltmas�
            "EVes",     // EkstrofiVesikalis k�saltmas�
            "KPErk",    // KolonPullThroughErkek k�saltmas�
            "KPKad"     // KolonPullThroughKadin k�saltmas�
        ],
    },
};


let optionsVisitorsProfile = {
    series: [40, 60],
    labels: ["Kiz", "Erkek"],
    colors: ["#435ebe", "#55c6e8"],
    chart: {
        type: "donut",
        width: "100%",
        height: "350px",
    },
    legend: {
        position: "bottom",
    },
    plotOptions: {
        pie: {
            donut: {
                size: "30%",
            },
        },
    },
}



var chartProfileVisit = new ApexCharts(
    document.querySelector("#chart-profile-visit"),
    optionsProfileVisit
)
var chartVisitorsProfile = new ApexCharts(
    document.getElementById("chart-visitors-profile"),
    optionsVisitorsProfile
)

chartProfileVisit.render()
chartVisitorsProfile.render()
