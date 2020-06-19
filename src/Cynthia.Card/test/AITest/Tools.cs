using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Alsein.Extensions;
using Alsein.Extensions.Extensions;
using CompressTest;
using Cynthia.Card;
using Cynthia.Card.AI;
using Cynthia.Card.Server;
using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Driver;

namespace AITest
{
    public static class Tools
    {
        public static async Task AIBattle()
        {
            var game = new GwentServerGame(new GeraltNovaAI(), new ReaverHunterAI());

            Console.WriteLine("游戏开始~请稍等");
            var gameResult = await game.Play();

            Console.WriteLine("游戏结束,比分如下:\n");
            Console.WriteLine($"{gameResult.BluePlayerName}:\t {gameResult.BlueScore.Join(",")}");
            Console.WriteLine($"{gameResult.RedPlayerName}:\t {gameResult.RedScore.Join(",")}");
            Console.WriteLine($"胜利者为:{(gameResult.BlueWinCount > gameResult.BlueWinCount ? gameResult.BluePlayerName : gameResult.RedPlayerName)}");
        }

        public static async Task ConfirmExit()
        {
            await Task.CompletedTask;
            Console.WriteLine("\n按回车退出");
            Console.ReadLine();
        }
    }
}