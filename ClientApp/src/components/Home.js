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
          <li><strong>Filtering the brands you like</strong></li>
        </ul>
        <p>To get started, chose one of the currently available charts below or from the top navigation bar!</p>
        <ul>
          <li><Link to="/minijack">Mini jack</Link> - check which phones have the 3.5mm audio jack</li>
          <li><Link to="/infrared">Infrared</Link> - see which modern devices are able to control your TV</li>
          <li><Link to="/ram">RAM</Link> - display the devices that are good for multitasking</li>
        </ul>
        <p>Many more interesting graphs are currently in development!</p>
      </div>
    );
  }
}
