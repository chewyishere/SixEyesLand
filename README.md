# SixEyesLand
unity3D script for game SixEyesland

3D Virtual Reality Sparked by Streaming Sentiment Analysis
A Unity3D virtual reality world for the Oculus Rift with animations that evolve based on real-time streams of speech and text. 
Depending on the sentiment that is extracted from the stream of text, the world abruptly becomes bright and chaotic (“positive feelings”) or dark and slow (“negative feelings”).
The real-time stream can accomodate any number of people speaking into a microphone on a website we developed, which converts speech to text through the Web Speech API. In our demo built for DevFest 2015 hackathon, 
text streams through a NLTK sentiment analysis API, via calls from an AWS EC2 instance built on top of Node.js. 
