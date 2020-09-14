using System;
using System.Collections.Generic;
using System.Collections;

namespace circular_buffer
{
    class CircularBuffer<T> {
      private readonly T[] buffer;
      public int _size;

      /// <summary>
      /// Read pointer
      /// </summary>
      private int readInd;
      /// <summary>
      /// Write pointer
      /// </summary>
      private int writeInd;

      public CircularBuffer(int size) {
        _size = size;
      }

      public void Add(T val) {


        // inside case
        if(isAtEnd(writeInd)){
          writeInd = 0;
        } else {
          if(writeInd + 1 == readInd){
            // throw err
          } else {
            writeInd++;
          }
        }

        buffer[writeInd] = val;
      }

      public T Decrease() {
        // can we close the gap any further
        // if not just return current val
        if(!isCaughtUp()){
          // determine if ind is at end and update position
          if(isAtEnd(readInd)){
            readInd = 0;
          } else {
            readInd++;
          }
        }

        return buffer[readInd];
      }

      public bool isCaughtUp() {
        return readInd == writeInd;
      }

      public bool isAtEnd(int index){
        
        return index == buffer.Length -1;
      }
    }
}