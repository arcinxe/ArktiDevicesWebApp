import React, { Component } from 'react';
import DeviceType from './DeviceType';
import { Table } from 'reactstrap';
import ReactTable from 'react-table'
import 'react-table/react-table.css'


export default class DetailsTable extends Component {
  constructor(props) {
    super(props);
    this.state = {

    };
  }

  render() {

    return (
      <div >
        <ReactTable
          data={this.props.devicesDetails}
          columns={[
            {
              Header: "Brand",
              accessor: "brand"
            },
            {
              Header: "Name",
              accessor: "name"
            },
            {
              Header: "Device type",
              accessor: "deviceType",
              Cell: (row) => {
                return <DeviceType type={row.original.deviceType} />
              }, 
            },
            {
              Header: "RAM",
              accessor: "ram",
              Cell: (row) => {
                return <div>
                  {row.original.ram > 1000 ? row.original.ram / 1024 + "GB" : row.original.ram + "MB"}
                </div>
              }
            }
          ]}
          defaultPageSize={10}
          className="-striped -highlight"
        />
        {/* <Table striped responsive size="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Brand</th>
              <th>Name</th>
              <th>Device type</th>
              <th>RAM</th>
            </tr>
          </thead>
          <tbody>
            {this.props.devicesDetails.map((d, index) =>
              <tr key={d.name}>
                <td>{index + 1}</td>
                <td>{d.brand}</td>
                <td>{d.name}</td>
                <td><DeviceType type={d.deviceType} /></td>
                <td>{d.ram > 1000 ? d.ram / 1024 + "GB" : d.ram + "MB"}</td>
              </tr>
            )}
          </tbody>
        </Table> */}

      </div>
    )
  }
}

