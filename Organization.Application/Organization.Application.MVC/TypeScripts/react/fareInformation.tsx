/// <reference path="../../node_modules/@types/react/index.d.ts" />
import * as React from "react"
import * as ReactDom from 'react-dom'
import DropDownComponent from "../react/dropDownComponent"

import SelectOption from "../api/selectOption";
import DropDownData from "../api/dropDownData";

interface FareInformationProps extends React.Props<FareInformation> {
 
}

export default class FareInformation extends React.Component<FareInformationProps, {}>  {

    constructor(props: FareInformationProps) {
        super(props);
        this.onCountryChange = this.onCountryChange.bind(this);
        this.onStateChange = this.onStateChange.bind(this);
        this.onCityChange = this.onCityChange.bind(this);

    }

    state = { CountryOptions: Array<SelectOption>(), StateOptions: Array<SelectOption>(), CityOptions: Array<SelectOption>(), countryId: "0", stateId: "0", cityId: "0" };

    componentWillUpdate(nextProps, nextState) {
        if (this.state.countryId != nextState.countryId) {
            this.onCountryChange(Number(nextState.countryId));
        }
    }

    onCountryChange(e) {

        let selectedOption = e.target ? Number(e.target.value) : e;

        let dropDownData = new DropDownData();
        const request = async () => {
            var options = await dropDownData.GetStateOptions(selectedOption);
            this.setState({ StateOptions: options, countryId: selectedOption });
            if (options.length > 0) {
                this.onStateChange(this.state.stateId == "0" ? options[0].Value : this.state.stateId);
            } else {
                this.setState({ CityOptions: Array<SelectOption>() });
            }
        }

        request();

    }

    onStateChange(e) {

        let selectedOption = e.target ? Number(e.target.value) : e;

        let dropDownData = new DropDownData();
        const request = async () => {
            var options = await dropDownData.GetCities(selectedOption);
            this.setState({ CityOptions: options, stateId: selectedOption });
        }

        request();
    }

    onCityChange(e) {
        this.setState({ cityId: e.target.value })
        
    }

    findFareRateClick() {
        let selectedCountryId = $("select#CountryOptions option:selected").val(),
            selectedStateId = $("select#StateOptions option:selected").val(),
            selectedCityId = $("select#CityOptions option:selected").val();

        selectedCountryId = selectedCountryId == undefined ? 0 : selectedCountryId;
        selectedStateId = selectedStateId == undefined ? 0 : selectedStateId;
        selectedCityId = selectedCityId == undefined ? 0 : selectedCityId;

        window.location.href = "/Portal/Home/Index?CountryId=" + selectedCountryId + "&StateId=" + selectedStateId + "&cityId=" + selectedCityId;

        return false;
    }

    componentWillMount() {

        let dropDownData = new DropDownData();
        const request = async () => {
            var options = await dropDownData.GetCountryOptions();

            let countryId = $('input:hidden#CountryId').val();
            let stateId = $('input:hidden#StateId').val();
            let cityId = $('input:hidden#CityId').val();

            this.setState({ CountryOptions: options, countryId: countryId, stateId: stateId, cityId: cityId  });
        }

        request();
    }



    render() {

        return (
            <div>
                    <DropDownComponent SelectedValue={this.state.countryId} DropdownName={"CountryOptions"} OnChange={this.onCountryChange} Options={this.state.CountryOptions} />
                    {
                        this.state.StateOptions.length > 0 ?
                            <DropDownComponent SelectedValue={this.state.stateId} DropdownName={"StateOptions"} OnChange={this.onStateChange} Options={this.state.StateOptions} />
                            : null
                    }
                    {
                        this.state.CityOptions.length > 0 ?
                            <DropDownComponent SelectedValue={this.state.cityId} DropdownName={"CityOptions"} OnChange={this.onCityChange} Options={this.state.CityOptions} />
                            : null
                    }
                    <a onClick={this.findFareRateClick} className="btn btn-info mb-20" >Find Fare Rate</a>
            </div>
        );
    }

}


ReactDom.render(React.createElement(FareInformation), document.getElementById("countryContainer"));


$(document).ready(function () {
    // alert("Hi There");


});
