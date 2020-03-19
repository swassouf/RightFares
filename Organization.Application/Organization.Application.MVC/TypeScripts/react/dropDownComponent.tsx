/// <reference path="../../node_modules/@types/react/index.d.ts" />
import * as React from "react";
import SelectOption from "../api/selectOption";

interface DropDownComponentProps extends React.Props<DropDownComponent> {
    Options: Array<SelectOption>;
    OnChange: (e) => void;
    DropdownName: string;
    SelectedValue: string;
}

export default class DropDownComponent extends React.Component<DropDownComponentProps, {}> {

    componentWillMount() { }

    public render() {

        return (
            <select className={"form-control mb-20"} id={this.props.DropdownName} onChange={this.props.OnChange} value={this.props.SelectedValue}>

                {
                    this.props.Options.map((i) => {
                        return (<option key={i.Value.toString()} value={i.Value}  > {i.Text} </option>)
                    })


                }
            </select>
        );
    }

}
