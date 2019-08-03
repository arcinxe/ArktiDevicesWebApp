import React, { Component } from 'react';
import DeviceType from './DeviceType';
// import { Button } from 'reactstrap';
import ReactTable from 'react-table'
import 'react-table/react-table.css'
import Icon from '@mdi/react';
import { mdiClose, mdiCheck } from '@mdi/js';

export default class DetailsTable extends Component {
  constructor(props) {
    super(props);
    this.state = {

    };
    this.gsmArenaLinkHandling = this.gsmArenaLinkHandling.bind(this);
    this.formatData = this.formatData.bind(this);
    this.formatColumnName = this.formatColumnName.bind(this);
  }
  formatData(inputData) {
    let result = inputData;
    switch (this.props.chartType) {
      case "Ram":
        result = inputData > 1000 ? inputData / 1024 + "GB" : inputData + "MB"
        break;
      default:
        if (typeof inputData === "boolean")
          result = inputData
            ? <Icon path={mdiCheck} size={1} color="#00C853" />
            : <Icon path={mdiClose} size={1} color="#D32F2F" />
        break;
    }

    return result;
  }
  formatColumnName(chartType) {
    let name = chartType;
    switch (chartType) {
      case "Ram":
        name = "RAM"
        break;
      case "Types":
        name = "Type";
        break
      default:
        break;
    }
    return name;
  }
  gsmArenaLinkHandling(slug) {
    console.log(slug);
    window.open("https://gsmarena.com/" + slug + ".php");
  }

  render() {

    return (
      <div >
        <ReactTable
          data={this.props.devicesDetails.map((d, index) => {
            d.index = index + 1;
            return d
          })}
          columns={[
            {
              Header: "#",
              accessor: "index",
              maxWidth: 40,
            },
            {
              Header: "Name",
              accessor: "name",
              Cell: (row) => {
                return <a href={"https://gsmarena.com/" + row.original.slug + ".php"} target="_blank" rel="noopener noreferrer">{row.original.name}</a>
                // return <Button color="link" size="16px" onClick={() => this.gsmArenaLinkHandling(row.original.slug)} >{row.original.name}</Button>
              },
            },
            {
              Header: "Device type",
              accessor: "deviceType",
              maxWidth: 150,
              Cell: (row) => {
                return <DeviceType type={row.original.deviceType} />
              },
            },
            {
              Header: this.formatColumnName(this.props.chartType),
              accessor: "specificValue",
              show: this.props.chartType!=="Types",
              Cell: (row) => {
                return <div className="specific-value-div" style={{ textAlign: "center" }}>
                  {this.formatData(row.original.specificValue)}
                </div>
              }
            }
          ]}
          defaultPageSize={100}
          minRows={2}
          className="-striped -highlight"
        />
      </div>
    )
  }
}

