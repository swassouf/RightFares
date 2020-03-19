"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
/// <reference path="../../node_modules/@types/react/index.d.ts" />
var React = require("react");
var ReactDom = require("react-dom");
var dropDownComponent_1 = require("../react/dropDownComponent");
var dropDownData_1 = require("../api/dropDownData");
var FareInformation = /** @class */ (function (_super) {
    __extends(FareInformation, _super);
    function FareInformation(props) {
        var _this = _super.call(this, props) || this;
        _this.state = { CountryOptions: Array(), StateOptions: Array(), CityOptions: Array(), countryId: "0", stateId: "0", cityId: "0" };
        _this.onCountryChange = _this.onCountryChange.bind(_this);
        _this.onStateChange = _this.onStateChange.bind(_this);
        _this.onCityChange = _this.onCityChange.bind(_this);
        return _this;
    }
    FareInformation.prototype.componentWillUpdate = function (nextProps, nextState) {
        if (this.state.countryId != nextState.countryId) {
            this.onCountryChange(Number(nextState.countryId));
        }
    };
    FareInformation.prototype.onCountryChange = function (e) {
        var _this = this;
        var selectedOption = e.target ? Number(e.target.value) : e;
        var dropDownData = new dropDownData_1.default();
        var request = function () { return __awaiter(_this, void 0, void 0, function () {
            var options;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, dropDownData.GetStateOptions(selectedOption)];
                    case 1:
                        options = _a.sent();
                        this.setState({ StateOptions: options, countryId: selectedOption });
                        if (options.length > 0) {
                            this.onStateChange(this.state.stateId == "0" ? options[0].Value : this.state.stateId);
                        }
                        else {
                            this.setState({ CityOptions: Array() });
                        }
                        return [2 /*return*/];
                }
            });
        }); };
        request();
    };
    FareInformation.prototype.onStateChange = function (e) {
        var _this = this;
        var selectedOption = e.target ? Number(e.target.value) : e;
        var dropDownData = new dropDownData_1.default();
        var request = function () { return __awaiter(_this, void 0, void 0, function () {
            var options;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, dropDownData.GetCities(selectedOption)];
                    case 1:
                        options = _a.sent();
                        this.setState({ CityOptions: options, stateId: selectedOption });
                        return [2 /*return*/];
                }
            });
        }); };
        request();
    };
    FareInformation.prototype.onCityChange = function (e) {
        this.setState({ cityId: e.target.value });
    };
    FareInformation.prototype.findFareRateClick = function () {
        var selectedCountryId = $("select#CountryOptions option:selected").val(), selectedStateId = $("select#StateOptions option:selected").val(), selectedCityId = $("select#CityOptions option:selected").val();
        selectedCountryId = selectedCountryId == undefined ? 0 : selectedCountryId;
        selectedStateId = selectedStateId == undefined ? 0 : selectedStateId;
        selectedCityId = selectedCityId == undefined ? 0 : selectedCityId;
        window.location.href = "/Portal/Home/Index?CountryId=" + selectedCountryId + "&StateId=" + selectedStateId + "&cityId=" + selectedCityId;
        return false;
    };
    FareInformation.prototype.componentWillMount = function () {
        var _this = this;
        var dropDownData = new dropDownData_1.default();
        var request = function () { return __awaiter(_this, void 0, void 0, function () {
            var options, countryId, stateId, cityId;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, dropDownData.GetCountryOptions()];
                    case 1:
                        options = _a.sent();
                        countryId = $('input:hidden#CountryId').val();
                        stateId = $('input:hidden#StateId').val();
                        cityId = $('input:hidden#CityId').val();
                        this.setState({ CountryOptions: options, countryId: countryId, stateId: stateId, cityId: cityId });
                        return [2 /*return*/];
                }
            });
        }); };
        request();
    };
    FareInformation.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement(dropDownComponent_1.default, { SelectedValue: this.state.countryId, DropdownName: "CountryOptions", OnChange: this.onCountryChange, Options: this.state.CountryOptions }),
            this.state.StateOptions.length > 0 ?
                React.createElement(dropDownComponent_1.default, { SelectedValue: this.state.stateId, DropdownName: "StateOptions", OnChange: this.onStateChange, Options: this.state.StateOptions })
                : null,
            this.state.CityOptions.length > 0 ?
                React.createElement(dropDownComponent_1.default, { SelectedValue: this.state.cityId, DropdownName: "CityOptions", OnChange: this.onCityChange, Options: this.state.CityOptions })
                : null,
            React.createElement("a", { onClick: this.findFareRateClick, className: "btn btn-info mb-20" }, "Find Fare Rate")));
    };
    return FareInformation;
}(React.Component));
exports.default = FareInformation;
ReactDom.render(React.createElement(FareInformation), document.getElementById("countryContainer"));
$(document).ready(function () {
    // alert("Hi There");
});
//# sourceMappingURL=fareInformation.js.map