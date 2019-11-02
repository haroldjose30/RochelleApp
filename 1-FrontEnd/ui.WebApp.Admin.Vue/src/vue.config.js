module.exports = {
    devServer: {
      proxy: 'https://localhost:5001'
    },
    configureWebpack: {
      devtool: 'source-map'
    }
  }