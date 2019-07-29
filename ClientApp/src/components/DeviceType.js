import React, { Component } from 'react';
import Icon from '@mdi/react';
import { mdiCellphone, mdiCellphoneBasic, mdiTablet, mdiWatch } from '@mdi/js';

export default class DeviceType extends Component {
    // constructor(props) {
    //     super(props);
    //     this.state = {

    //     };
    // }

    render() {
        let icon = "";
        switch (this.props.type) {
            case "smartphone":
                icon = mdiCellphone;
                break;
            case "phone":
                icon = mdiCellphoneBasic;
                break;
            case "smartwatch":
                icon = mdiWatch;
                break;
            case "tablet":
                icon = mdiTablet;
                break;
            default:
                break;
        }
        return (
            <div >
                <Icon path={icon} size={1} color="#212529"/><span> {this.props.type}</span>
            </div>
        )
    }
}