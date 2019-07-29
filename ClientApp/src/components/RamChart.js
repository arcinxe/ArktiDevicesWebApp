import React, { Component } from 'react';
import MyResponsiveBarTest from './MyResponsiveBarTest';
import { Table, Spinner } from 'reactstrap';
import Select from 'react-select';


export class RamChart extends Component {
  static displayName = RamChart.name;

  constructor(props) {
    super(props);
    this.state = { phones: [], brands: [], loading: true, selectedBrands: [], selectedDevicesDetails: [], selectedBar: {} };

    this.fetchData = this.fetchData.bind(this);
    this.handleSelectingBrands = this.handleSelectingBrands.bind(this);
    this.handleBarClick = this.handleBarClick.bind(this);
  }

  componentDidMount() {
    this.fetchData();
  }

  componentDidUpdate(prevProps, prevState) {
    if (JSON.stringify(prevState.selectedBrands.map(b => b.value)) !== JSON.stringify(this.state.selectedBrands.map(b => b.value))) {
      // console.log("componentWillUpdate event occurred");
      //console.log(this.state.selectedBrands.map(b => b.label + " " + b.value));
      this.fetchData();
    }

  }

  fetchData() {
    //console.log("starting fetch");
    //console.log(this.state.selectedBrands.map(b => b.label + " " + b.value));

    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    //console.log(brandsIds);
    let query = 'api/PhonesData/PhonesRam?selectedBrandsIds=' + brandsIds;
    //console.log(query);
    fetch(query)
      .then(response => response.json())
      .then(data => {
        console.log(data);
        let formatedData = data.map(y => {
          let result = Object.assign({}, { year: y.year }, y.memory.reduce((reduced, next) => {
            let keys = Object.keys(next);
            reduced[next[keys[0]]] = next[keys[1]];
            return reduced;
          }, {}));
          return result;
        });
        this.setState({ phones: formatedData, loading: false });
        //console.log("result from phonesWithJack");
        console.log(formatedData);
      });
  }

  handleSelectingBrands(selectedBrands) {
    //console.log("selectedBrands");
    //console.log(selectedBrands.map(b => b.label + " " + b.value));
    this.setState({ selectedBrands: selectedBrands, selectedDevicesDetails: [] });
  }

  handleBarClick(...theArgs) {
    //console.log("clicked on the bar")
    var event = theArgs[0];
    //console.log(event);
    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    let query = 'api/PhonesData/PhonesRamDetails?year=' + event.indexValue + '&ramAmount=' + event.id + '&selectedBrandsIds=' + brandsIds;
    //console.log(query);
    fetch(query)
      .then(response => response.json())
      .then(data => {
        //console.log("setting state to this");
        //console.log(data);
        this.setState({ selectedDevicesDetails: data });
      });
  }
  render() {
    let keys = ["<1GB", "1GB", "2GB", "3GB", "4GB", "6GB", "8GB", "10GB", "12GB"];
    let indexBy = "year";
    let labelTextColor = "#000";
    // let colors = { scheme: 'category10' };
    let colors = ['#0091B2','#00E0B6','#00DB5F','#00D60D','#42D200','#8DCD00','#C8BB00','#C36D00','#BF2200',];
    // let colors =[ '#240041', '#480544', '#6D0B47', '#B5154D', '#A3124C', '#DA2B52', '#FF4057', '#FF615C', '#ff8260',];
    // let colors =[ '#0A2F51', '#0D4761', '#116270', '#147E7B', '', '#48B16D', '#74C67A', '#ADDAA1', '#DEEDCF',];
    // let colors =[ 'rgb(128, 0, 38)', 'rgb(189, 0, 38)','rgb(227, 26, 28)', 'rgb(252, 78, 42)','rgb(253, 141, 60)'];
    let contents = this.state.loading
      ? <div><p><em>Loading...</em></p> <Spinner color="info" /> </div>
      : <MyResponsiveBarTest data={this.state.phones} keys={keys} indexBy={indexBy} onClick={this.handleBarClick} colors={colors} labelTextColor={labelTextColor}></MyResponsiveBarTest>

    return (
      <div>

        <Select
          defaultValue={[]}
          isMulti
          onChange={this.handleSelectingBrands}
          closeMenuOnSelect={false}
          name="colors"
          options={this.props.brands}
          className="basic-multi-select"
          classNamePrefix="select"
        />
        <div style={{ height: 500 }}>
          {contents}
        </div>

        <Table striped responsive size="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Brand</th>
              <th>Name</th>
              <th>RAM</th>
            </tr>
          </thead>
          <tbody>
            {this.state.selectedDevicesDetails.map((d, index) =>
              <tr key={d.name}>
                <td>{index + 1}</td>
                <td>{d.brand}</td>
                <td>{d.name}</td>
                <td>{d.ram > 1000 ? d.ram / 1024 + "GB" : d.ram + "MB"}</td>
              </tr>
            )}
          </tbody>
        </Table>
      </div >

    );
  }
}
