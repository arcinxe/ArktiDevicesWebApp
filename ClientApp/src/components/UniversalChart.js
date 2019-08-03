import React, { Component } from 'react';
import MyResponsiveBarTest from './MyResponsiveBarTest';
// import colorThemes from './Colors';
import DetailsTable from './DetailsTable';
import { Spinner } from 'reactstrap';
import Select from 'react-select';
// import Icon from '@mdi/react';
import { } from '@mdi/js';


export class UniversalChart extends Component {
  static displayName = UniversalChart.name;

  constructor(props) {
    super(props);
    this.state = {
      devices: [],
      brands: [],
      keys: [],
      loading: true,
      selectedDeviceTypes: [],
      selectedBrands: [],
      selectedDevicesDetails: [],
      selectedBar: {},
      selectedChartType: { label: "Device types", value: "Types" }
    };

    this.fetchData = this.fetchData.bind(this);
    this.handleSelectingBrands = this.handleSelectingBrands.bind(this);
    this.handleSelectingDeviceTypes = this.handleSelectingDeviceTypes.bind(this);
    this.handleSelectingChartType = this.handleSelectingChartType.bind(this);
    this.handleBarClick = this.handleBarClick.bind(this);
  }

  componentDidMount() {
    this.fetchData();
  }

  componentDidUpdate(prevProps, prevState) {
    if (JSON.stringify(prevState.selectedBrands.map(b => b.value)) !== JSON.stringify(this.state.selectedBrands.map(b => b.value))) {
      //console.log("componentWillUpdate event occurred");
      //console.log(this.state.selectedBrands.map(b => b.label + " " + b.value));
      this.fetchData();
    }
    if (JSON.stringify(prevState.selectedDeviceTypes.map(b => b.value)) !== JSON.stringify(this.state.selectedDeviceTypes.map(b => b.value)))
      this.fetchData();
    if (prevState.selectedChartType.value !== this.state.selectedChartType.value) {
      this.setState({ selectedDevicesDetails: [] });
      this.fetchData()
    }
  }

  fetchData() {
    //console.log("starting fetch");
    //console.log(this.state.selectedBrands.map(b => b.label + " " + b.value));

    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    brandsIds = brandsIds === "" ? 0 : brandsIds;
    let deviceTypesAbbreviations = this.state.selectedDeviceTypes.map(b => b.value).join('');
    //console.log(brandsIds);
    let query = 'api/DevicesData/' + this.state.selectedChartType.value + '?selectedBrandsIds=' + brandsIds + '&deviceTypes=' + deviceTypesAbbreviations;
    console.log(query);
    fetch(query)
      // .then(res => res.text())          // convert to plain text
      // .then(text => console.log(text))
      .then(response => response.json())
      .then(data => {
        console.log(data);
        let formatedData = data.data;
        if (this.state.selectedChartType.value === "Ram") {
          formatedData = data.data.map(y => {
            let result = Object.assign({}, { year: y.year }, y.memory.reduce((reduced, next) => {
              let keys = Object.keys(next);
              reduced[next[keys[0]]] = next[keys[1]];
              return reduced;
            }, {}));
            return result;
          });
        }
        this.setState({ devices: formatedData, loading: false, keys: data.keys });
        console.log(formatedData);
      });
  }

  handleSelectingBrands(selectedBrands) {
    // console.log("selectedBrands");
    //console.log(selectedBrands.map(b => b.label + " " + b.value));
    this.setState({ selectedBrands: selectedBrands });
  }
  handleSelectingDeviceTypes(selectedDeviceTypes) {
    // console.log("selectedDeviceTypes");
    // console.log(selectedDeviceTypes.map(b => b.label + " " + b.value));
    this.setState({ selectedDeviceTypes: selectedDeviceTypes });
  }
  handleSelectingChartType(selectedChartType) {
    // console.log("selectedChartType");
    // console.log(selectedChartType);
    this.setState({ selectedChartType: selectedChartType });
  }

  handleBarClick(...theArgs) {
    var event = theArgs[0];
    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    let deviceTypesAbbreviations = this.state.selectedDeviceTypes.map(b => b.value).join('');
    let query = 'api/DevicesData/' + this.state.selectedChartType.value + 'Details?year=' + event.indexValue + '&value=' + event.id + '&selectedBrandsIds=' + brandsIds + '&deviceTypes=' + deviceTypesAbbreviations;
    console.log(query);
    fetch(query)
      .then(response => response.json())
      .then(data => {
        console.log(data);
        this.setState({ selectedDevicesDetails: data });
      });
  }
  render() {
    let indexBy = "year";
    let labelTextColor = "#000";

    let contents = this.state.loading
      ? <div><h1>Loading...</h1> <Spinner color="info" /> </div>
      : <MyResponsiveBarTest data={this.state.devices} keys={this.state.keys} indexBy={indexBy} onClick={this.handleBarClick}
        labelTextColor={labelTextColor} itemsSpacing={30} name={this.state.selectedChartType.value}></MyResponsiveBarTest>

    return (
      <div>

        <Select
          defaultValue={[]}
          isMulti
          placeholder={"Filter brands..."}
          onChange={this.handleSelectingBrands}
          closeMenuOnSelect={false}
          name="colors"
          options={this.props.brands}
          className="basic-multi-select"
          classNamePrefix="select"
        />
        <Select
          defaultValue={[]}
          isMulti
          placeholder={"Filter device types..."}
          onChange={this.handleSelectingDeviceTypes}
          closeMenuOnSelect={false}
          name="colors"
          options={this.props.devices}
          className="basic-multi-select"
          classNamePrefix="select"
        />
        <Select
          placeholder={"Select chart type..."}
          defaultValue={{ label: "Device types", value: "Types" }}
          onChange={this.handleSelectingChartType}
          name="colors"
          options={this.props.charts.map(c => ({ label: c.name, value: c.path }))}
          classNamePrefix="select"
        />
        <div style={{ height: 500 }}>
          {contents}
        </div>
        <DetailsTable devicesDetails={this.state.selectedDevicesDetails} chartType={this.state.selectedChartType.value} />
      </div >

    );
  }
}
