import React from 'react'
import { ResponsiveBar } from '@nivo/bar'
const MyResponsiveBarTest = ({ data, keys, indexBy, onClick, labelTextColor, name }) => {
    console.log("name")
    console.log(name)
    let finalColors = [];

    console.log("colors")
    switch (name) {
        case "Ram":
            finalColors = ["#0091B2", "#00E0B6", "#00DB5F", "#00D60D", "#42D200", "#8DCD00", "#C8BB00", "#C36D00", "#BF2200",];
            break;
        case "Types":
            finalColors = ["#A3124C", "#D12952", "#FF615C", "#FF987C",];
            break;
        case "Infrared":
        case "MiniJack":
            finalColors = ["#3399ff", "#f20051",];
            break;
        default:
            break;
    }


    return (<ResponsiveBar data={data} keys={keys} indexBy={indexBy} margin={{ top: 50, right: 10, bottom: 50, left: 30 }} padding={0.3} colors={finalColors} labelTextColor={labelTextColor} borderColor={{ from: 'color', modifiers: [['darker', 1.6]] }} axisBottom={{
        tickSize: 5,
        tickPadding: 5,
        tickRotation: -90,
        legend: 'years',
        legendPosition: 'middle',
        legendOffset: 42
    }} axisLeft={{
        tickSize: 5,
        tickPadding: 5,
        tickRotation: 0,
        legend: 'amount of phone models',
        legendPosition: 'middle',
        legendOffset: 10
    }} labelSkipWidth={12} labelSkipHeight={12}
        // labelTextColor={{ from: 'color', modifiers: [['darker', 1.6]] }}
        legends={[
            {
                dataFrom: 'keys',
                anchor: 'top-left',
                direction: 'column',
                justify: false,
                translateX: 40,
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
            }
        ]} animate={true} motionStiffness={90} motionDamping={15} onClick={onClick} />);
}


export default MyResponsiveBarTest


















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
