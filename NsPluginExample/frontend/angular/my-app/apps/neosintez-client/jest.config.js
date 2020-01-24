module.exports = {
  name: 'neosintez-client',
  preset: '../../jest.config.js',
  coverageDirectory: '../../coverage/apps/neosintez-client',
  snapshotSerializers: [
    'jest-preset-angular/AngularSnapshotSerializer.js',
    'jest-preset-angular/HTMLCommentSerializer.js'
  ]
};
