import React, { Component } from 'react';
// import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';


export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello!</h1>
        <p>Let's check how the parameters of the mobile devices have been changing over time!</p>
        <p>Features:</p>
        <ul>
          <li><strong>Displaying data using colorful bar charts</strong></li>
          <li><strong>Checking details of each part of the graphs</strong></li>
          <li><strong>Filtering the brands and device types you are interested in</strong></li>
        </ul>
        <p>Few of the currently available charts below or from the top navigation bar!</p>
        <ul>
          <li><strong>Mini jack</strong> - check which phones have the 3.5mm audio jack</li>
          <li><strong>Infrared</strong> - see which modern devices are able to control your TV</li>
          <li><strong>RAM</strong> - display the devices that are good for multitasking</li>
        </ul>
        <p>To get started, go to the <Link to="/charts">Charts page!</Link></p>
        <p>Many more interesting graphs are currently in development!</p>
      </div>
    );
  }
}
