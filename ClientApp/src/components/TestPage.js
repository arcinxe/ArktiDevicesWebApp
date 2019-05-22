import React, { Component } from 'react';
import MyResponsiveBarTest from './MyResponsiveBarTest';
import { CustomInput } from 'reactstrap';
// import 'bootstrap/dist/css/bootstrap.min.css';
export class TestPage extends Component {
  static displayName = TestPage.name;

  constructor(props) {
    super(props);
    this.state = { phones: [], brands: [], loading: true, showOnlySelected: false };


    this.togglePopularBrands = this.togglePopularBrands.bind(this);
    this.fetchData = this.fetchData.bind(this);
  }
  togglePopularBrands() {
    console.log("current state: "+this.state.showOnlySelected)
    let showSelected = this.state.showOnlySelected;
    this.setState({ showOnlySelected: !showSelected });
    console.log("current state: "+this.state.showOnlySelected)
    this.fetchData(false);
  }
  componentDidMount() {
    fetch('api/PhonesData/Brands')
      .then(response => response.json())
      .then(brands => {
        this.setState({ brands: brands })
        console.log(brands);
      });
      this.fetchData(true);
      
    }
    fetchData(firstTime) {
      let status =firstTime? this.state.showOnlySelected: !this.state.showOnlySelected;
      console.log("state before fetching: "+this.state.showOnlySelected)
    let selectedBrandsQuery = status ? "?selectedBrandsIds=1,2,6,8,13,30,32,34,35,48,52,54,58,63,66,67,79,80,82,88,100,106,111" : "";
    let query = 'api/PhonesData/PhonesWithJack' + selectedBrandsQuery;
    // debugger;                                                                                                                    
    fetch(query)
      .then(response => response.json())
      //     .then(res => res.text())          // convert to plain text
      // .then(text => console.log(text))
      .then(data => {
        this.setState({ phones: data, loading: false });
        console.log(query);
        console.log(data);
      });
  }

  render() {
    var keys = ['jack', 'noJack'];
    var indexBy = "year";
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : <MyResponsiveBarTest data={this.state.phones} keys={keys} indexBy={indexBy}></MyResponsiveBarTest>
    return (
      <div>
        <div>
          <CustomInput type="checkbox" id="all-brands-checkbox" onChange={this.togglePopularBrands} checked={this.state.showOnlySelected} label="Show only most popular brands" />
        </div>

        <div style={{ height: 500 }}>
          {contents}
        </div>
      </div>

    );
  }
}
