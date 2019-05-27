import React, { Component } from 'react';
import MyResponsiveBarTest from './MyResponsiveBarTest';
// import BasicMulti from './BasicMulti';
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
    let query = 'api/PhonesData/Brands';
    console.log(query);
    fetch(query)
      .then(response => response.json())
      .then(brands => {
        this.setState({ brands: brands.map(brand => ({ label: brand.name, value: brand.id })) })
        console.log("result from brands");
        console.log(brands);


      });
    this.fetchData();

  }
  componentDidUpdate(prevProps, prevState) {
    if (JSON.stringify(prevState.selectedBrands.map(b => b.value)) !== JSON.stringify(this.state.selectedBrands.map(b => b.value))) {
      console.log("componentWillUpdate event occured");
      console.log(this.state.selectedBrands.map(b => b.label + " " + b.value));
      this.fetchData();
    }

  }

  fetchData() {
    console.log("starting fetch");
    console.log(this.state.selectedBrands.map(b => b.label + " " + b.value));


    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    console.log(brandsIds);
    // let selectedBrandsQuery = status ? "?selectedBrandsIds=1,2,6,8,13,30,32,34,35,48,52,54,58,63,66,67,79,80,82,88,100,106,111" : "";
    // let selectedBrandsQuery = this.state.selectedBrands.length < 0 ? ("" + brandsIds) : "";
    let query = 'api/PhonesData/PhonesRam?selectedBrandsIds=' + brandsIds;
    console.log(query);
    fetch(query)
      .then(response => response.json())
      //     .then(res => res.text())          // convert to plain text
      // .then(text => console.log(text))
      .then(data => {
        let formatedData = data.map(y => {
          let result = Object.assign({}, { year: y.year }, y.memory.reduce((reduced, next) =>{ 
           let keys = Object.keys(next);
           reduced[next[keys[0]]] = next[keys[1]];
            // console.log(reduced)
            return reduced;
          }, {}));
          return result;
        });
        this.setState({ phones: formatedData, loading: false });
        console.log("result from phonesWithJack");
        console.log(formatedData);
      });
  }

  handleSelectingBrands(selectedBrands) {
    console.log("selectedBrands");
    console.log(selectedBrands.map(b => b.label + " " + b.value));
    this.setState({ selectedBrands: selectedBrands, selectedDevicesDetails:[] });
  }

  handleBarClick(...theArgs) {
    console.log("clicked on the bar")
    var event = theArgs[0];
    console.log(event);
    let brandsIds = this.state.selectedBrands.map(b => b.value).join();
    let withJack = event.id === 'jack' ? 'true' : 'false';
    let query = 'api/PhonesData/PhonesWithJackDetails?year=' + event.indexValue + '&withJack=' + withJack + '&selectedBrandsIds=' + brandsIds;
    console.log(query);
    fetch(query)
      .then(response => response.json())
      //     .then(res => res.text())          // convert to plain text
      // .then(text => console.log(text))
      .then(data => {
        console.log("setting state to this");
        console.log(data);
        this.setState({ selectedDevicesDetails: data.devices });
        // this.setState({ selectedDevices: data });
      });

    // let devices = this.state.phones.filter(p => p.year === event["indexValue"])[0][(event["id"] + "Devices")];
    // console.log(devices);
    // console.log(this.state.phones.filter(p => p.year === theArgs.indexValue)[0].jackDevices)
  }
  render() {
    // const { selectedOption } = this.state;
    let keys = ["<1GB", "1GB", "2GB", "3GB", "4GB", "6GB", "8GB", "10GB", "12GB"];
    let indexBy = "year";
    let labelTextColor="#000";
    // let colors={scheme: 'category10' };
    let colors = ['#0091B2','#00E0B6','#00DB5F','#00D60D','#42D200','#8DCD00','#C8BB00','#C36D00','#BF2200',];
    // let colors =[ '#240041', '#480544', '#6D0B47', '#B5154D', '#A3124C', '#DA2B52', '#FF4057', '#FF615C', '#ff8260',];
    // let colors =[ '#0A2F51', '#0D4761', '#116270', '#147E7B', '', '#48B16D', '#74C67A', '#ADDAA1', '#DEEDCF',];
    // let colors =[ 'rgb(128, 0, 38)', 'rgb(189, 0, 38)','rgb(227, 26, 28)', 'rgb(252, 78, 42)','rgb(253, 141, 60)'];
    let contents = this.state.loading
      ? <div><p><em>Loading...</em></p> <Spinner color="info" /> </div>
      : <MyResponsiveBarTest data={this.state.phones} keys={keys} indexBy={indexBy} onClick={this.handleBarClick} colors={colors} labelTextColor={labelTextColor}></MyResponsiveBarTest>

    // let table = this.state.loading
    //   ? <tbody>
    //     <tr>
    //       <th scope="row">1</th>
    //       <td>pause</td>
    //       <td>Otto</td>
    //     </tr>
    //   </tbody> :
    //   <tbody>{
    //     this.state.selectedDevices.map(d => {
    //       <tr>
    //         <th scope="row">sdfsd</th>
    //         <td>{d.name}</td>
    //         <td>test</td>
    //       </tr>
    //     })
    //   }
    //   </tbody>

    // // debugger;
    // console.log("table log")
    // console.log(table)
    // console.log("shit")
    // var foo = this.state.phones.filter(p => p.year === "2008")[0];
    // if (foo != null)
    //   console.log(this.state.phones.filter(p => p.year === "2008")[0].jackDevices);
    // let count = 1;
    return (
      <div>

        <Select
          defaultValue={[]}
          isMulti
          onChange={this.handleSelectingBrands}
          closeMenuOnSelect={false}
          name="colors"
          options={this.state.brands}
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
              <th>Device type</th>
            </tr>
          </thead>
          <tbody>
            {this.state.selectedDevicesDetails.map((d, index) =>
              <tr key={d.name}>
                <td>{index + 1}</td>
                <td>{d.brand}</td>
                <td>{d.name}</td>
                <td>{d.deviceType}</td>
              </tr>
            )}
          </tbody>
        </Table>
      </div >

    );
  }
}
