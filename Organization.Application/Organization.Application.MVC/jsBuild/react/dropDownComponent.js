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
var React = require("react");
var DropDownComponent = (function (_super) {
    __extends(DropDownComponent, _super);
    function DropDownComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DropDownComponent.prototype.componentWillMount = function () { };
    DropDownComponent.prototype.render = function () {
        return (React.createElement("select", null, this.props.Options.map(function (i) {
            return (React.createElement("option", { value: i.Value },
                " ",
                i.Text,
                " "));
        })));
    };
    return DropDownComponent;
}(React.Component));
exports.default = DropDownComponent;
//# sourceMappingURL=dropDownComponent.js.map