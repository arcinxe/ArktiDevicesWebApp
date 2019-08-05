import React, { Component } from 'react';
import Icon from '@mdi/react';
import { mdiCellphone, mdiCellphoneBasic, mdiTablet, mdiWatch } from '@mdi/js';
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';

export default class DeviceTypeButtons extends Component {
    constructor(props) {
        super(props);

        this.state = { cSelected: ['s', 'w', 't', 'p'] };

        this.onCheckboxBtnClick = this.onCheckboxBtnClick.bind(this);
    }

    onCheckboxBtnClick(selected) {
        const index = this.state.cSelected.indexOf(selected);
        if (index < 0) {
            this.state.cSelected.push(selected);
        } else {
            this.state.cSelected.splice(index, 1);
        }
        this.setState({ cSelected: [...this.state.cSelected] });
        this.props.onChange([...this.state.cSelected]);
    }
    render() {
        let noOutline = { outline: "none" };
        return (
            <div>

                <Tooltip title="smartphones">
                    <IconButton aria-label="smartphones" style={noOutline} onClick={() => this.onCheckboxBtnClick('s')}>
                        <Icon path={mdiCellphone} size={1.25} color={this.state.cSelected.includes('s') ? "#191919" : "#999999"} />
                    </IconButton>
                </Tooltip>
                <Tooltip title="smartwatches">
                    <IconButton aria-label="smartwatches" style={noOutline} onClick={() => this.onCheckboxBtnClick('w')}>
                        <Icon path={mdiWatch} size={1.25} color={this.state.cSelected.includes('w') ? "#191919" : "#999999"} />
                    </IconButton>
                </Tooltip>
                <Tooltip title="tablets">
                    <IconButton aria-label="tablets" style={noOutline} onClick={() => this.onCheckboxBtnClick('t')}>
                        <Icon path={mdiTablet} size={1.25} color={this.state.cSelected.includes('t') ? "#191919" : "#999999"} />
                    </IconButton>
                </Tooltip>
                <Tooltip title="phones">
                    <IconButton aria-label="phones" style={noOutline} onClick={() => this.onCheckboxBtnClick('p')}>
                        <Icon path={mdiCellphoneBasic} size={1.25} color={this.state.cSelected.includes('p') ? "#191919" : "#999999"} />
                    </IconButton>
                </Tooltip>
            </div>
        )
    }
}