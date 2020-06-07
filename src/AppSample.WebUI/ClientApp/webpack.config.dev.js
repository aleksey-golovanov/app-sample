const merge = require("webpack-merge");
const common = require("./webpack.config");

module.exports = merge(common, {
    output: {
        publicPath: "/"
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            }
        ]
    },
    devServer: {
        historyApiFallback: true
    },
    devtool: "#source-map"
});
