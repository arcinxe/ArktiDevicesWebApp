import React, { Component } from 'react';
import { ResponsiveBar } from '@nivo/bar'
export default class MyResponsiveBarTest extends Component {
    constructor(props) {
        super(props);
        this.state = { test: [] };
    }

    render() {
        let finalColors = [];
        switch (this.props.name) {
            case "Ram":
            case "UsbVersion":
            case "UsbPort":
                finalColors = ["#0091B2", "#00E0B6", "#00DB5F", "#00D60D", "#42D200", "#8DCD00", "#C8BB00", "#C36D00", "#BF2200",];
                break;
            case "Types":
                finalColors = ["#A3124C", "#D12952", "#FF615C", "#FF987C",];
                break;
            case "Infrared":
            case "MiniJack":
                finalColors = ["#3399ff", "#f20051",];
                break;
            case "ScreenDensity":
                finalColors = ["#0091B2", "#00E0B6", "#00DB5F", "#00D60D", "#42D200", "#8DCD00", "#C8BB00", "#C36D00", "#BF2200",];
                break;
            case "AndroidVersion":
                finalColors = ["#f22090", "#e420f2", "#c899f2", "#201ff2", "#2074f2", "#20acf2", "#20e4f2", "#20f2ac", "#90f220", "#a8bf78", "#f2e420", "#f2ac1f", "#f2741f", "#f29999", "#f2201f"];
                break;
            case "ScreenDiagonal":
                finalColors = ["#e81010", "#f5d28c", "#2ff511", "#428dcf", "#db7dc8", "#e89284", "#e8de4a", "#4ae874", "#4a4ae8", "#f54e91", "#f56c11", "#c7f511", "#10e8bd", "#9a8cf5", "#e84a5f", "#e89e4a", "#a5cf76", "#46bddb", "#f511e6"];
                break;
            default:
                // finalColors = { scheme: 'set3' };
                finalColors = ["#0091B2", "#00E0B6", "#00DB5F", "#00D60D", "#42D200", "#8DCD00", "#C8BB00", "#C36D00", "#BF2200",];
                break;
        }

        let keys = new Set(this.props.data.map(y => Object.keys(y)).flat());
        keys.delete("year");
        // console.log(keys);
        let regexp = new RegExp(this.props.unit);

        let sortedKeys = [...keys]
        // console.log(sortedKeys);

        switch (this.props.name) {
            case "Types":
                sortedKeys = ["cellphones", "smartphones", "smartwatches", "tablets",]
                break;
            case "Infrared":
                sortedKeys = ["infrared", "no infrared"]
                break;
            case "MiniJack":
                sortedKeys = ["audio jack", "no audio jack"]
                break;
            case "AndroidVersion":
                sortedKeys = ["Cupcake", "Donut", "Éclair", "Froyo", "Gingerbread", "Honeycomb", "Ice Cream Sandwich", "Jelly Bean", "KitKat", "Lollipop", "Marshmallow", "Nougat", "Oreo", "Pie",]
                break;
            default:
                sortedKeys = sortedKeys.sort((a, b) => a.replace(regexp, "").replace("<1", "") - b.replace(regexp, "").replace("<1", ""));
                break;
        }

        let data = this.props.data;

        let test = JSON.parse(JSON.stringify(data))
        test = test.map(y => {
            let total = Object.keys(y).reduce((reduced, current) => {
                if (current !== "year")
                    reduced += y[current];
                return reduced;
            }, 0);
            let percentage = (total / 100);
            Object.keys(y).forEach(key => {
                if (key !== "year") {
                    let innerPercentage = parseFloat((y[key] / total) * 100);
                    y[key + "1"] = y[key];
                    y[key] = innerPercentage;
                    y[key + "3"] = (y[key] / percentage);
                    if (!y[key]) y[key] = 0;
                }
            });
            y.percentage = percentage;
            y.total = total;
            return y;
        });
        if (this.props.scaled) {
            data = test;
        }


        const format = v => `${v.toFixed(2)}%`
        const simpleFormat = v => `${Math.floor(v)}%`
        const noFormat = v => v;
        return (
            <ResponsiveBar data={data} keys={sortedKeys} indexBy={this.props.indexBy}
                labelFormat={this.props.scaled ? simpleFormat : noFormat}
                tooltipFormat={this.props.scaled ? format : noFormat}
                // axisLeft={{ format }}

                margin={{ top: 50, right: 10, bottom: 50, left: 60 }} padding={0.3}
                colors={finalColors} labelTextColor={this.props.labelTextColor}
                borderColor={{ from: 'color', modifiers: [['darker', 1.6]] }}
                axisBottom={{
                    tickSize: 5,
                    tickPadding: 5,
                    tickRotation: -90,
                    legend: 'years',
                    legendPosition: 'middle',
                    legendOffset: 42,
                    onClick: this.props.onClick,
                }} axisLeft={{
                    tickSize: 5,
                    tickPadding: 17,
                    tickRotation: 0,
                    legend: (this.props.scaled ? 'percentage' : 'amount') + ' of different device models',
                    legendPosition: 'middle',
                    legendOffset: -15,
                    format: this.props.scaled ? simpleFormat : noFormat,
                }} labelSkipWidth={12} labelSkipHeight={12}
                // labelTextColor={{ from: 'color', modifiers: [['darker', 1.6]] }}
                legends={this.props.scaled ? [] : [
                    {
                        dataFrom: 'keys',
                        anchor: 'top-left',
                        direction: 'column',
                        justify: false,
                        translateX: 0,
                        // translateY: -40,
                        itemsSpacing: 10,
                        itemWidth: 50,
                        itemHeight: 10,
                        itemDirection: 'left-to-right',
                        itemOpacity: 0.85,
                        symbolSize: 15,
                        effects: [
                            {
                                on: 'hover',
                                style: {
                                    itemOpacity: 0.7
                                }
                            }
                        ]
                    },
                ]}
                animate={true} motionStiffness={250} motionDamping={40} onClick={this.props.onClick} groupMode={this.props.grouped ? "grouped" : "stacked"} />);
    }
}

















// import React, { Component } from 'react';

// import {
//   XYPlot,
//   XAxis,
//   YAxis,
//   VerticalGridLines,
//   HorizontalGridLines,
//   MarkSeries,
//   Hint, LineSeries
// } from 'react-vis';

// export class Chart extends Component {
//   static displayName = Chart.name;

//   constructor(props) {
//     super(props);
//     this.state = {
//       value: null
//     };
//   }

//   _forgetValue = () => {
//     this.setState({
//       value: null
//     });
//   };

//   _rememberValue = value => {
//     this.setState({value});
//   };

//   render() {
//     const {value} = this.state;
//     return (
//       <XYPlot width={300} height={300}>
//         <VerticalGridLines />
//         <HorizontalGridLines />
//         <XAxis />
//         <YAxis />
//         <MarkSeries
//           onValueMouseOver={this._rememberValue}
//           onValueMouseOut={this._forgetValue}
//           data={[{x: 1, y: 10}, {x: 2, y: 5}, {x: 3, y: 15}]}
//         />
//         {value ? <Hint value={value} /> : null}
//       </XYPlot>
//     );
//   }
// }
