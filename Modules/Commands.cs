using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace nameBot.Modules {
     public class Commands : ModuleBase<SocketCommandContext> {

          [Command("fname")]
               public async Task fname(){
                await ReplyAsync(randFName);
               }

          [Command("ping")]
             public async Task Ping()
             {
                 await ReplyAsync("pong");
             }


     private string randFName() {
          var rand = new Random();
          string[] stChunks = File.ReadAllLines("startChunks.txt");
          string[] midChunks = File.ReadAllLines("middleChunks.txt");
          string[] endChunks = File.ReadAllLines("endChunks.txt");
          string[] oneSyll = File.ReadAllLines("oneSyllable.txt");
          string name = "";
          int syllables = rand.Next(1,5);
          switch (syllables) {
            case 1:
              name += oneSyll[rand.Next(0,oneSyll.length)];
              break;
            case 2:
              name += stChunks[rand.Next(0, stChunks.length)];
              name += endChunks[rand.Next(0, endChunks.length)];
              break;
            case 3:
              name += stChunks[rand.Next(0, stChunks.length)];
              name += midChunks[rand.Next(0, midChunks.length)];
              name += endChunks[rand.Next(0, endChunks.length)];
              break;
            case 4:
              name += stChunks[rand.Next(0, stChunks.length)];
              name += midChunks[rand.Next(0, midChunks.length)];
              name += midChunks[rand.Next(0, midChunks.length)];
              name += endChunks[rand.Next(0, endChunks.length)];
              break;
          }
          return name;
     }
     }



}
