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
Object.defineProperty(exports, "__esModule", { value: true });
/// <reference path="../../node_modules/@types/react/index.d.ts" />
var React = require("react");
var DropDownComponent = /** @class */ (function (_super) {
    __extends(DropDownComponent, _super);
    function DropDownComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DropDownComponent.prototype.componentWillMount = function () { };
    DropDownComponent.prototype.render = function () {
        return (React.createElement("select", { className: "form-control mb-20", id: this.props.DropdownName, onChange: this.props.OnChange, value: this.props.SelectedValue }, this.props.Options.map(function (i) {
            return (React.createElement("option", { key: i.Value.toString(), value: i.Value },
                " ",
                i.Text,
                " "));
        })));
    };
    return DropDownComponent;
}(React.Component));
exports.default = DropDownComponent;
//# sourceMappingURL=dropDownComponent.js.map