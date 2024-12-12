module.exports = {
  parser: "@typescript-eslint/parser", // Ensures ESLint can parse TypeScript
  parserOptions: {
    ecmaVersion: 2020, // Enables parsing of modern JavaScript features
    sourceType: "module", // Ensures ESLint understands imports/exports
    ecmaFeatures: {
      jsx: true, // Enable parsing of JSX syntax
    },
  },
  extends: [
    "eslint:recommended", // Basic ESLint recommended rules
    "plugin:react/recommended", // React-specific linting rules
    "plugin:@typescript-eslint/recommended", // TypeScript-specific linting rules
  ],
  rules: {
    // Custom ESLint rules can be added here
  },
  settings: {
    react: {
      version: "detect", // Automatically detects the React version
    },
  },
};
