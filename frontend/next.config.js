// next.config.js
module.exports = {
  experimental: {
    turbo: true, // Enable Turbopack
    appDir: true, // If you're using the app directory for routing
  },
  webpack(config, { isServer }) {
    // Custom Webpack configurations if needed
    if (!isServer) {
      config.resolve.fallback = { fs: false }; // Prevent fs from being bundled on the client-side
    }
    return config;
  },
};
