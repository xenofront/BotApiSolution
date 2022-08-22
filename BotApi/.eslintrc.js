module.exports = {
  env: {
    browser: true,
    es6: true,
    node: true
  },
  extends: ["plugin:@typescript-eslint/recommended"],
  parser: "@typescript-eslint/parser",
  rules: {
    //     "@typescript-eslint/indent": "error",
    // "@typescript-eslint/naming-convention": "error",
    //     indent: "error",
    //     "jsdoc/check-alignment": "error",
    //     "jsdoc/check-indentation": "error",
    //     "jsdoc/newline-after-description": "error",
    // "max-len": [
    //   "error",
    //   {
    //     code: 140
    //   }
    // ],
    // "@typescript-eslint/tslint/config": [
    //   "error",
    //   {
    //     rules: {
    //       ban: [true, ["_", "extend"], ["_", "isNull"], ["_", "isDefined"]],
    //       "label-undefined": true,
    //       "no-duplicate-key": true,
    //       "no-trailing-comma": true,
    //       "no-unreachable": true,
    //       typedef: [
    //         true,
    //         "call-signature",
    //         "parameter",
    //         "property-declaration",
    //         "variable-declaration"
    //       ],
    //       "use-strict": [true, "check-module", "check-function"]
    //     }
    //   }
    // ]
    curly: "error",
    eqeqeq: ["error", "smart"],
    quotes: "error",
    radix: "error",
    semi: "error",
    "dot-notation": "error",
    "no-shadow": "warn",
    "@typescript-eslint/no-var-requires": "off",
    "@typescript-eslint/no-explicit-any": "off",
    "@typescript-eslint/explicit-module-boundary-types": "off",
    "@typescript-eslint/no-empty-function": "error",
    "@typescript-eslint/no-unused-expressions": "error",
    "@typescript-eslint/no-unused-vars": "error",
    "@typescript-eslint/no-use-before-define": "off",
    "@typescript-eslint/quotes": ["error", "double"],
    "@typescript-eslint/semi": ["error", "always"],
    "@typescript-eslint/type-annotation-spacing": "error",
    "@typescript-eslint/member-delimiter-style": [
      "error",
      {
        multiline: {
          delimiter: "semi",
          requireLast: true
        },
        singleline: {
          delimiter: "semi",
          requireLast: false
        }
      }
    ],
    "brace-style": ["error", "1tbs"],
    "dot-notation": "error",
    "eol-last": "off",
    "guard-for-in": "error",
    "id-blacklist": "off",
    "id-match": "off",
    "no-bitwise": "error",
    "no-caller": "error",
    "no-console": [
      "error",
      {
        allow: [
          "log",
          "warn",
          "dir",
          "timeLog",
          "assert",
          "clear",
          "count",
          "countReset",
          "group",
          "groupEnd",
          "table",
          "dirxml",
          "error",
          "groupCollapsed",
          "Console",
          "profile",
          "profileEnd",
          "timeStamp",
          "context"
        ]
      }
    ],
    "no-debugger": "error",
    "no-empty": "error",
    "no-empty-function": "error",
    "no-eval": "error",
    "no-new-wrappers": "error",
    "no-redeclare": "error",
    "no-trailing-spaces": "error",
    "no-underscore-dangle": "off",
    "no-unused-expressions": "error",
    "no-unused-labels": "error",
    "no-unused-vars": "error",
    "spaced-comment": [
      "error",
      "always",
      {
        markers: ["/"]
      }
    ]
  }
};
