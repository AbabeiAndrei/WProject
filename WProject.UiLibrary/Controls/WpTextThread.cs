using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    public partial class WpTextThread : UserControl
    {
        #region Fields

        private const int HORIZONTAL_MESSAGE_PADDING = 12;
        private const int START_MESSAGE_PADDING = 4;
        private const int ARROW_SIZE = 16;

        private ObservableCollection<ChatMessage> _chatMessages;
        private int _messagesLimit;
        private Font _smallInfoFont;
        private bool _messagesHaveChanges;
        private Color _sendMessageColor;
        private Color _reciveMessageColor;
        private Color _sendMessageForeColor;
        private Color _reciveMessageForeColor;

        #endregion

        #region Properties

        [DefaultValue(true)]
        [Category("Behavior")]
        public virtual bool ClearOnSend { get; set; } = true;

        [Category("Action")]
        public event EventHandler OnSend;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual IList<ChatMessage> Messages
        {
            get
            {
                return _chatMessages;
            }
            set
            {
                _chatMessages = new ObservableCollection<ChatMessage>(value);

                _chatMessages.CollectionChanged += ChatMessagesOnCollectionChanged;
            }
        }

        [DefaultValue(100)]
        public int MessagesLimit
        {
            get
            {
                return _messagesLimit;
            }
            set
            {
                _messagesLimit = value;

                RecalculateMessagesHeight();
                Refresh();
            }
        }

        [DefaultValue(4)]
        public int PaddingBetweenMessages
        {
            get
            {
                return _messagesLimit;
            }
            set
            {
                _messagesLimit = value;

                RecalculateMessagesHeight();
                Refresh();
            }
        }

        public Color SendMessageColor
        {
            get
            {
                return _sendMessageColor;
            }
            set
            {
                _sendMessageColor = value;
                pnlThread.Refresh();
            }
        }

        public Color ReciveMessageColor
        {
            get
            {
                return _reciveMessageColor;
            }
            set
            {
                _reciveMessageColor = value;
                pnlThread.Refresh();

            }
        }

        public Color SendMessageForeColor
        {
            get
            {
                return _sendMessageForeColor;
            }
            set
            {
                _sendMessageForeColor = value;
                pnlThread.Refresh();
            }
        }

        public Color ReciveMessageForeColor
        {
            get
            {
                return _reciveMessageForeColor;
            }
            set
            {
                _reciveMessageForeColor = value;
                pnlThread.Refresh();
            }
        }

        #endregion

        #region Overrides of UserControl

        public override string Text
        {
            get
            {
                return txtMessage.Text;
            }
            set
            {
                txtMessage.Text = value;
            }
        }

        #endregion

        #region Constructors

        public WpTextThread()
        {
            InitializeComponent();

            InitChatMessages();

            _smallInfoFont = new Font("Segoe UI", 7f);

            btnSend.Parent = null;

            txtMessage.LeftButton = btnSend;

            SendMessageColor = WpThemeColors.Blue;
            ReciveMessageColor = WpThemeColors.Teal;
            MessagesLimit = 100;
        }

        public WpTextThread(IEnumerable<ChatMessage> messages)
            : this()
        {

            InitChatMessages(messages);
        }

        #endregion

        #region Events

        private void btnSend_Click(object sender, EventArgs e)
        {
            pnlMain.ScrollToBottom();

            OnSend?.Invoke(this, EventArgs.Empty);

            if (ClearOnSend)
                txtMessage.Clear();
        }

        private void ChatMessagesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RecalculateMessagesHeight();
            pnlThread.Refresh();
        }

        private void pnlThread_Paint(object sender, PaintEventArgs e)
        {
            _messagesHaveChanges = false;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (Messages == null || Messages.Count == 0)
            {
                using (Brush mb = new SolidBrush(WpThemeColors.Shadow))
                    e.Graphics.DrawString("No messages",
                                          _smallInfoFont,
                                          mb,
                                          pnlThread.ClientRectangle,
                                          new StringFormat
                                          {
                                              LineAlignment = StringAlignment.Center,
                                              Alignment = StringAlignment.Center
                                          });
                return;
            }
            int mlastx = START_MESSAGE_PADDING;

            foreach (ChatMessage msg in Messages.Take(MessagesLimit).Reverse())
                DrawChatMessage(msg, e.Graphics, ref mlastx);
        }

        #endregion

        #region Overrides of Control

        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                RecalculateMessagesHeight();
            }
            finally
            {
                base.OnSizeChanged(e);
            }
        }

        #endregion

        #region Private methods

        private void InitChatMessages(IEnumerable<ChatMessage> messages = null)
        {
            _chatMessages = messages != null
                                ? new ObservableCollection<ChatMessage>(messages)
                                : new ObservableCollection<ChatMessage>();

            _chatMessages.CollectionChanged += ChatMessagesOnCollectionChanged;
            RecalculateMessagesHeight();
        }

        private void RecalculateMessagesHeight()
        {
            if(Messages == null)
                return;

            using (var mgfx = pnlThread.CreateGraphics())
                pnlThread.Height = Messages.Take(MessagesLimit)
                                           .Select(m => CalculateMessageHeight(m, mgfx) + PaddingBetweenMessages)
                                           .DefaultIfEmpty(16)
                                           .Sum();

            _messagesHaveChanges = true;
        }

        private int CalculateMessageHeight(ChatMessage msg, Graphics gfx)
        {
            var mmsgHeight = gfx.MeasureString(msg.Message,
                                               Font,
                                               new SizeF(pnlThread.Width -
                                                         HORIZONTAL_MESSAGE_PADDING -
                                                         START_MESSAGE_PADDING*3,
                                                         int.MaxValue));

            return (int)mmsgHeight.Height + 16;
        }

        private void DrawChatMessage(ChatMessage msg, Graphics gfx, ref int lastx)
        {
            int mleft = msg.Send ? HORIZONTAL_MESSAGE_PADDING : START_MESSAGE_PADDING;
            int mwidth = pnlThread.Width - HORIZONTAL_MESSAGE_PADDING - START_MESSAGE_PADDING*2;

            var ms = gfx.MeasureString(msg.Message, Font, new Size(mwidth - START_MESSAGE_PADDING*2, int.MaxValue));

            int mheight = (int)ms.Height + lastx;

            Brush mbkbrush = new SolidBrush(msg.Send ? SendMessageColor : ReciveMessageColor);

            Point[] mpoints;

            if(msg.Send)
                mpoints = new[]
                {
                    new Point(mleft, lastx), 
                    new Point(mwidth, lastx), 
                    new Point(mwidth, mheight + ARROW_SIZE), 
                    new Point(mwidth - ARROW_SIZE, mheight), 
                    new Point(mleft, mheight), 
                    new Point(mleft, lastx)
                };
            else
                mpoints = new[]
                {
                    new Point(mleft, lastx),
                    new Point(mwidth, lastx),
                    new Point(mwidth, mheight),
                    new Point(mleft + ARROW_SIZE, mheight),
                    new Point(mleft, mheight + ARROW_SIZE),
                    new Point(mleft, lastx)
                };


            gfx.FillPolygon(mbkbrush, mpoints);
            lastx += START_MESSAGE_PADDING + (int)ms.Height;
        }

        #endregion

        #region Public methods

        public virtual void ClearText()
        {
            txtMessage.Clear();
        }

        #endregion
    }
}
