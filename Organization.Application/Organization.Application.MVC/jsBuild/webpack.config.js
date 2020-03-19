module.exports = {
    entry: "./TypeScripts/react/fareInformation.tsx",
    output: {
        filename: "./jsBuild/bundle.js"
    },
    resolve: {
        extensions: ['.js', '.ts', '.tsx']
    },
    devtool: "source-map",
    module: {
        loaders: [
            {
                test: /\.(ts|tsx)?$/,
                exclude: /node_modules/,
                loader: ["ts-loader"]
            }
        ]
    },
    externals: {
        "react": "React",
        "react-dom": "ReactDOM"
    },
};
//# sourceMappingURL=webpack.config.js.map