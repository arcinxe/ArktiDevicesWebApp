import React from 'react'
import { ResponsiveBar } from '@nivo/bar'
// make sure parent container have a defined height when using
// responsive component, otherwise height will be 0 and
// no chart will be rendered.
// website examples showcase many properties,
// you'll often use just a few of them.
const MyResponsiveBar = ({ data /* see data tab */ }) => (
    <ResponsiveBar
        data={[
          {
            "country": "AD",
            "hot dog": 99,
            "hot dogColor": "hsl(169, 70%, 50%)",
            "burger": 116,
            "burgerColor": "hsl(351, 70%, 50%)",
            "sandwich": 18,
            "sandwichColor": "hsl(174, 70%, 50%)",
            "kebab": 26,
            "kebabColor": "hsl(2, 70%, 50%)",
            "fries": 137,
            "friesColor": "hsl(318, 70%, 50%)",
            "donut": 170,
            "donutColor": "hsl(87, 70%, 50%)"
          },
          {
            "country": "AE",
            "hot dog": 62,
            "hot dogColor": "hsl(46, 70%, 50%)",
            "burger": 177,
            "burgerColor": "hsl(25, 70%, 50%)",
            "sandwich": 0,
            "sandwichColor": "hsl(76, 70%, 50%)",
            "kebab": 117,
            "kebabColor": "hsl(15, 70%, 50%)",
            "fries": 176,
            "friesColor": "hsl(329, 70%, 50%)",
            "donut": 73,
            "donutColor": "hsl(240, 70%, 50%)"
          },
          {
            "country": "AF",
            "hot dog": 25,
            "hot dogColor": "hsl(150, 70%, 50%)",
            "burger": 150,
            "burgerColor": "hsl(237, 70%, 50%)",
            "sandwich": 147,
            "sandwichColor": "hsl(6, 70%, 50%)",
            "kebab": 140,
            "kebabColor": "hsl(321, 70%, 50%)",
            "fries": 157,
            "friesColor": "hsl(329, 70%, 50%)",
            "donut": 84,
            "donutColor": "hsl(213, 70%, 50%)"
          },
          {
            "country": "AG",
            "hot dog": 126,
            "hot dogColor": "hsl(272, 70%, 50%)",
            "burger": 3,
            "burgerColor": "hsl(109, 70%, 50%)",
            "sandwich": 43,
            "sandwichColor": "hsl(219, 70%, 50%)",
            "kebab": 98,
            "kebabColor": "hsl(235, 70%, 50%)",
            "fries": 186,
            "friesColor": "hsl(158, 70%, 50%)",
            "donut": 53,
            "donutColor": "hsl(116, 70%, 50%)"
          },
          {
            "country": "AI",
            "hot dog": 123,
            "hot dogColor": "hsl(207, 70%, 50%)",
            "burger": 70,
            "burgerColor": "hsl(66, 70%, 50%)",
            "sandwich": 13,
            "sandwichColor": "hsl(203, 70%, 50%)",
            "kebab": 46,
            "kebabColor": "hsl(195, 70%, 50%)",
            "fries": 75,
            "friesColor": "hsl(176, 70%, 50%)",
            "donut": 197,
            "donutColor": "hsl(109, 70%, 50%)"
          },
          {
            "country": "AL",
            "hot dog": 177,
            "hot dogColor": "hsl(272, 70%, 50%)",
            "burger": 148,
            "burgerColor": "hsl(59, 70%, 50%)",
            "sandwich": 108,
            "sandwichColor": "hsl(179, 70%, 50%)",
            "kebab": 142,
            "kebabColor": "hsl(80, 70%, 50%)",
            "fries": 92,
            "friesColor": "hsl(179, 70%, 50%)",
            "donut": 109,
            "donutColor": "hsl(304, 70%, 50%)"
          },
          {
            "country": "AM",
            "hot dog": 19,
            "hot dogColor": "hsl(49, 70%, 50%)",
            "burger": 165,
            "burgerColor": "hsl(284, 70%, 50%)",
            "sandwich": 108,
            "sandwichColor": "hsl(251, 70%, 50%)",
            "kebab": 167,
            "kebabColor": "hsl(92, 70%, 50%)",
            "fries": 168,
            "friesColor": "hsl(227, 70%, 50%)",
            "donut": 127,
            "donutColor": "hsl(23, 70%, 50%)"
          }
        ]}
        keys={[ 'hot dog', 'burger', 'sandwich', 'kebab', 'fries', 'donut' ]}
        indexBy="country"
        margin={{ top: 50, right: 130, bottom: 50, left: 60 }}
        padding={0.3}
        colors={{ scheme: 'nivo' }}
        defs={[
            {
                id: 'dots',
                type: 'patternDots',
                background: 'inherit',
                color: '#38bcb2',
                size: 4,
                padding: 1,
                stagger: true
            },
            {
                id: 'lines',
                type: 'patternLines',
                background: 'inherit',
                color: '#eed312',
                rotation: -45,
                lineWidth: 6,
                spacing: 10
            }
        ]}
        fill={[
            {
                match: {
                    id: 'fries'
                },
                id: 'dots'
            },
            {
                match: {
                    id: 'sandwich'
                },
                id: 'lines'
            }
        ]}
        borderColor={{ from: 'color', modifiers: [ [ 'darker', 1.6 ] ] }}
        axisTop={null}
        axisRight={null}
        axisBottom={{
            tickSize: 5,
            tickPadding: 5,
            tickRotation: 0,
            legend: 'country',
            legendPosition: 'middle',
            legendOffset: 32
        }}
        axisLeft={{
            tickSize: 5,
            tickPadding: 5,
            tickRotation: 0,
            legend: 'food',
            legendPosition: 'middle',
            legendOffset: -40
        }}
        labelSkipWidth={12}
        labelSkipHeight={12}
        labelTextColor={{ from: 'color', modifiers: [ [ 'darker', 1.6 ] ] }}
        legends={[
            {
                dataFrom: 'keys',
                anchor: 'bottom-right',
                direction: 'column',
                justify: false,
                translateX: 120,
                translateY: 0,
                itemsSpacing: 2,
                itemWidth: 100,
                itemHeight: 20,
                itemDirection: 'left-to-right',
                itemOpacity: 0.85,
                symbolSize: 20,
                effects: [
                    {
                        on: 'hover',
                        style: {
                            itemOpacity: 1
                        }
                    }
                ]
            }
        ]}
        animate={true}
        motionStiffness={90}
        motionDamping={15}
    />
)


export default MyResponsiveBar


















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
