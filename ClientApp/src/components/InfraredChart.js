import React, { Component } from 'react';
import MyResponsiveBarTest from './MyResponsiveBarTest';
// import BasicMulti from './BasicMulti';
import { Table, Spinner } from 'reactstrap';
import Select from 'react-select';


export class InfraredChart extends Component {
  static displayName = InfraredChart.name;

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
        this.setState({ brands: brands.map(brand => ({ label: brand.name+" ["+brand.numberOfDevices+"]", value: brand.id })) })
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
    let query = 'api/PhonesData/PhonesWithInfrared?selectedBrandsIds=' + brandsIds;
    console.log(query);
    fetch(query)
      .then(response => response.json())
      //     .then(res => res.text())          // convert to plain text
      // .then(text => console.log(text))
      .then(data => {
        this.setState({ phones: data, loading: false });
        console.log("result from phonesWithInfrared");
        console.log(data);
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
    let withInfrared = event.id === 'infrared' ? 'true' : 'false';
    let query = 'api/PhonesData/PhonesWithInfraredDetails?year=' + event.indexValue + '&withInfrared=' + withInfrared + '&selectedBrandsIds=' + brandsIds;
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
    // console.log(this.state.phones.filter(p => p.year === theArgs.indexValue)[0].infraredDevices)
  }
  render() {
    // const { selectedOption } = this.state;
    let keys = [ 'noInfrared', 'infrared'];
    let indexBy = "year";
    let colors =[ '#42A5F5', '#E57373'];
    let contents = this.state.loading
      ? <div><p><em>Loading...</em></p> <Spinner color="info" /> </div>
      : <MyResponsiveBarTest data={this.state.phones} keys={keys} indexBy={indexBy} onClick={this.handleBarClick} colors={colors} itemsSpacing={30}></MyResponsiveBarTest>

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
    //   console.log(this.state.phones.filter(p => p.year === "2008")[0].infraredDevices);
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
