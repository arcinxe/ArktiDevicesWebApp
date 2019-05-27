import React from 'react'
import { ResponsiveBar } from '@nivo/bar'
// make sure parent container have a defined height when using
// responsive component, otherwise height will be 0 and
// no chart will be rendered.
// website examples showcase many properties,
// you'll often use just a few of them.
const MyResponsiveBarTest = ({ data, keys, indexBy, onClick, colors, labelTextColor /* see data tab */ }) => (
    <ResponsiveBar
        data={data}
        keys={keys}
        indexBy={indexBy}
        margin={{ top: 50, right: 10, bottom: 50, left: 30 }}
        padding={0.3}
        colors={colors}
        labelTextColor={labelTextColor}
        borderColor={{ from: 'color', modifiers: [['darker', 1.6]] }}
        axisBottom={{
            tickSize: 5,
            tickPadding: 5,
            tickRotation: -90,
            legend: 'years',
            legendPosition: 'middle',
            legendOffset: 42
        }}
        axisLeft={{
            tickSize: 5,
            tickPadding: 5,
            tickRotation: 0,
            legend: 'amount of phone models',
            legendPosition: 'middle',
            legendOffset: 10
        }}
        labelSkipWidth={12}
        labelSkipHeight={12}
        // labelTextColor={{ from: 'color', modifiers: [['darker', 1.6]] }}
        legends={[
            {
                dataFrom: 'keys',
                anchor: 'top-left',
                direction: 'row',
                justify: false,
                translateX: 0,
                translateY: -40,
                itemsSpacing: 2,
                itemWidth: 50,
                itemHeight: 20,
                itemDirection: 'left-to-right',
                itemOpacity: 0.85,
                symbolSize: 10,
                effects: [
                    {
                        on: 'hover',
                        style: {
                            itemOpacity: 0.7
                        }
                    }
                ]
            }
        ]}
        //  defs={[
        //     {
        //         id: 'infrared',
        //         type: 'patternLines',
        //         background: '#E57373',
        //         color: '#E57373',
        //         // size: 4,
        //         // padding: 1,
        //         stagger: true
        //     },
        //     {
        //         id: 'default',
        //         type: 'patternLines',
        //         background: '#42A5F5',
        //         color: '#42A5F5',
        //     }
        // ]}
        // fill={[
        //     {
        //         match: {
        //             id: 'infrared'
        //         },
        //         id: 'infrared'
        //     },
        //     {
        //         match: {
        //             id: 'noInfrared'
        //         },
        //         id: 'default'
        //     },
        //     {
        //         match: {
        //             id: 'jack'
        //         },
        //         id: 'default'
        //     }
        // ]}
        animate={true}
        motionStiffness={90}
        motionDamping={15}
        onClick={onClick}
    />
)


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
