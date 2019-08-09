import React, { Component } from 'react';
import MyResponsiveBarTest from './MyResponsiveBarTest';
import DetailsTable from './DetailsTable';
import DeviceTypeButtons from './DeviceTypeButtons';
import { Spinner } from 'reactstrap';
import Select from 'react-select';
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
      selectedDeviceTypes: ['s', 'w', 't', 'p'],
      selectedBrands: [],
      selectedDevicesDetails: [],
      selectedBar: {},
      selectedChartType: { label: "Device types", value: "Types" },
      grouped: false,
      scaled: false,
      test: [],
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
      this.fetchData();
    }
    if (JSON.stringify(prevState.selectedDeviceTypes) !== JSON.stringify(this.state.selectedDeviceTypes))
      this.fetchData();
    if (prevState.selectedChartType.value !== this.state.selectedChartType.value) {
      this.setState({ selectedDevicesDetails: [] });
      this.fetchData()
    }
  }

  fetchData() {
    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    brandsIds = brandsIds === "" ? 0 : brandsIds;
    let deviceTypesAbbreviations = this.state.selectedDeviceTypes.join('');
    let query = 'api/DevicesData/' + this.state.selectedChartType.value + '?selectedBrandsIds=' + brandsIds + '&deviceTypes=' + deviceTypesAbbreviations;
    console.log(query);
    fetch(query)
      .then(response => response.json())
      .then(data => {
        console.log(data);
        let formatedData = data.data;
        if (true || this.state.selectedChartType.value === "Ram" || this.state.selectedChartType.value === "Types") {
          console.log(this.state.selectedChartType.value);
          formatedData = data.data.map(y => {
            let result = Object.assign({}, { year: y.year }, y.data.reduce((reduced, next) => {
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
    this.setState({ selectedBrands: selectedBrands });
  }
  handleSelectingChartType(selectedChartType) {
    this.setState({ selectedChartType: selectedChartType });
  }
  handleSelectingDeviceTypes(selectedDeviceTypes, grouped, scaled) {
    this.setState({ selectedDeviceTypes: selectedDeviceTypes, grouped: grouped, scaled: scaled });
  }


  handleBarClick(...theArgs) {
    console.log(theArgs)
    var fullYear = (typeof theArgs[1] === "string" && theArgs[1].length === 4);
    if (fullYear) console.log("FULL YEAR")
    var event = theArgs[0];
    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    let deviceTypesAbbreviations = this.state.selectedDeviceTypes.join('');
    let query = 'api/DevicesData/' + this.state.selectedChartType.value + 'Details?year=' + (fullYear ? theArgs[1] : event.indexValue) + '&value=' + (fullYear ? "" : event.id) + '&selectedBrandsIds=' + brandsIds + '&deviceTypes=' + deviceTypesAbbreviations;
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
    let labelTextColor = "#191919";
    let contents = this.state.loading
      ? <div><h1>Loading...</h1> <Spinner color="info" /> </div>
      : <MyResponsiveBarTest data={this.state.devices} keys={this.state.keys} indexBy={indexBy} onClick={this.handleBarClick}
        labelTextColor={labelTextColor} itemsSpacing={30} name={this.state.selectedChartType.value} grouped={this.state.grouped} scaled={this.state.scaled} ></MyResponsiveBarTest>

    return (
      <div>
        <Select
          placeholder={"Change chart type..."}
          // defaultValue={{ label: "Device types", value: "Types" }}
          onChange={this.handleSelectingChartType}
          name="colors"
          options={this.props.charts.map(c => ({ label: c.name, value: c.path }))}
          classNamePrefix="select"
        />
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
        <DeviceTypeButtons
          onChange={this.handleSelectingDeviceTypes} />
        <div style={{ height: 500 }}>
          {contents}
        </div>
        <DetailsTable devicesDetails={this.state.selectedDevicesDetails} chartType={this.state.selectedChartType.value} />
      </div >

    );
  }
}
