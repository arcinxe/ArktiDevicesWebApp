import React, { Component } from 'react';

export class Phones extends Component {
  static displayName = 'Phones';

  constructor (props) {
    super(props);
    this.state = { phones: [], loading: true };

    fetch('api/PhonesData/DeviceDetails')
      .then(response => response.json())
      .then(data => {
        this.setState({ phones: data, loading: false });
      });
  }

  static renderPhonesTable (phones) {
console.log(phones);

    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Brand</th>
            <th>Name(C)</th>
            <th>Processor(F)</th>
            <th>RAM</th>
          </tr>
        </thead>
        <tbody>
          {phones.map(phone =>
            <tr key={phone.deviceDetailID}>
              <td>{phone.brand}</td>
              <td>{phone.name}</td>
              <td>{phone.cpu.producer + ' ' + phone.cpu.name}</td>
              <td>{phone.memory.randomAccess}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Phones.renderPhonesTable(this.state.phones);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
